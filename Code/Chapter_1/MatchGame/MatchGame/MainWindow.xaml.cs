
// These are like importing special tools we need to build our game
// Think of it as getting all your art supplies before starting a project
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

// This is like creating a special box to put all our game stuff in
/* What are namespaces? 
 * Namespaces in C# are like containers or organizers for your code. They help you group related classes, interfaces, and other code elements together. This organization makes your code easier to manage, especially in large projects.

Why use namespaces?

To avoid naming conflicts: You can have classes with the same name in different namespaces.
To organize code: It helps structure your project logically.
To control access: It provides a way to control the scope and visibility of your code elements.
How namespaces work:

They create a "scope" for the names of the things inside them.
You can have nested namespaces (namespaces inside namespaces).
The "using" keyword allows you to use elements from a namespace without fully qualifying their names.
*/

/* Real-world analogy of namespaces:
Think of a namespace as a library. Inside this library, you have different shelves (nested namespaces) for different subjects. On each shelf, you have books (classes). The library's organization helps you find the book you need quickly.

In the MatchGame example:
namespace MatchGame
{
    // Game code here...
}
This puts all the code for the match game into a container called "MatchGame". If someone else wants to use your game in their project, they can refer to it as MatchGame.MainWindow for example, avoiding conflicts with any other MainWindow classes they might have.

Best practices:

Name namespaces clearly and descriptively.
Use PascalCase for namespace names (e.g., System.Collections, not system.collections).
Organize namespaces to reflect the structure of your project.
Use nested namespaces for further organization when needed.

*/

/* Functions:

Definition: A function is a self-contained block of code that performs a specific task.
Characteristics:

It has a name.
It can take inputs (parameters).
It can return a value (or be void if it doesn't return anything).
It can be called and reused multiple times.


Purpose: Functions help organize code, promote reusability, and break down complex problems into smaller, manageable parts.
In C#, standalone functions are typically static methods within a class.
 
 */

/*Classes:

Definition: A class is a blueprint or template for creating objects. It encapsulates data and behavior into a single unit.
Characteristics:

It can have properties (data) and methods (behavior).
It serves as a custom data type.
It supports object-oriented programming concepts like inheritance and polymorphism.


Purpose: Classes help organize code, model real-world entities or concepts, and provide a way to create reusable and modular code.
In C#, everything is part of a class (or similar constructs like structs or records).
 
 */

/*Methods:

Definition: A method is a function that belongs to a class or object.
Characteristics:

It defines the behavior of objects created from the class.
It can access and manipulate the object's data (properties).
It can be public, private, or protected, controlling access from outside the class.
It can be static (belonging to the class itself) or instance (belonging to objects of the class).


Purpose: Methods encapsulate behavior within a class, allowing objects to perform actions or computations.
In C#, methods are always part of a class (or similar construct).
 * 
 */

/*Functions vs Methods: 
 * In C#, standalone functions don't exist outside of classes. What we typically call "functions" in C# are actually static methods of a class.
 */

/*Classes vs Functions/Methods: 
 * Classes are the overall structure that contains both data (properties) and behavior (methods). Functions and methods define behavior, while classes encompass both data and behavior.
 */

/*
 */



namespace MatchGame
{

            // We're getting a special clock to keep track of time in our game
            using System.Windows.Threading;

    // This is like the game board - it's where we put all our game stuff
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    // This is the main part of our game, like the game board

    /*Class: MainWindow
The main class is MainWindow, which represents the window and all its components. It inherits from Window, the base class for WPF windows.
    */

    /* BaseClass Library BCL: The Base Class Library (BCL) is a fundamental component of the .NET Framework and its successors (.NET Core and .NET 5+). It provides a comprehensive, reusable set of classes, interfaces, and value types that form the foundation for building applications in the .NET ecosystem. The BCL is an essential part of the .NET Framework's Common Language Runtime (CLR) and is also included in the .NET SDK.

Here’s everything you need to know about the BCL:

1. Definition of Base Class Library (BCL)
BCL is a collection of reusable types, including classes, interfaces, and structures, that developers use to build various types of applications in the .NET ecosystem.
It includes classes for system functionalities like I/O, threading, data access, security, collections, networking, and more.
BCL serves as a foundation for .NET developers, providing common functionality to prevent reinventing the wheel when developing applications.
2. Scope of the BCL
The BCL is a subset of the larger .NET Class Library, which includes additional libraries for application models like ASP.NET, Windows Forms, WPF, Entity Framework, etc.
While the Framework Class Library (FCL) refers to all the libraries provided by .NET, BCL focuses on core functionality that almost any application will need.
BCL is language-neutral, meaning it can be used across any .NET-supported languages like C#, VB.NET, F#, etc.
     * 
     * 
*/
    public partial class MainWindow : Window
   
    {
        // This is our game clock - it helps us count time

        DispatcherTimer timer = new DispatcherTimer();  // DispatcherTimer timer: This timer updates the game's time every 0.1 seconds. 

        // These are like scorekeepers - one counts time, the other counts matches
        int tenthsOfSecondsElapsed;  // This counts tiny parts of a second
                int matchesFound;  // This counts how many matches we've found

                // This is where we set up our game when it starts

    
        /* Constructor: MainWindow()
            The constructor initializes the game, sets the timer’s interval to 0.1 seconds, and wires up the Timer_Tick event handler. It then calls SetUpGame() to initialize the game.

         */
        public MainWindow()
        {
            // This line sets up all the stuff we can see in the game
            InitializeComponent();

                    // We're telling our clock to tick every 0.1 seconds
                    timer.Interval = TimeSpan.FromSeconds(.1);

            // Every time the clock ticks, we want to do something (update the time)
            /*Method: Timer_Tick
This method is triggered every 0.1 seconds by the timer:
It increments tenthsOfSecondsElapsed.
The elapsed time is displayed in a TextBlock named timeTextBlock in seconds.
When 8 matches are found (since there are 16 emojis and 8 pairs), the timer stops, and a message asking the player if they want to play again is added to the timeTextBlock.
*/

            timer.Tick += Timer_Tick;

            // Let's get our game ready to play!
            SetUpGame();
        }

                // This happens every time our game clock ticks (every 0.1 seconds)
                private void Timer_Tick(object sender, EventArgs e)
                {
                    // Count up the time
                    tenthsOfSecondsElapsed++;

                    // Show the time on the screen - we divide by 10 to show seconds instead of tenths of seconds
                    timeTextBlock.Text = (tenthsOfSecondsElapsed / 10F).ToString("0.0s");

                    // If we found all the matches (there are 8 pairs)...
                    if (matchesFound == 8)
                    {
                        // Stop the clock
                        timer.Stop();

                        // Show the final time and ask if they want to play again
                        timeTextBlock.Text = timeTextBlock.Text + " - Play again?";
                    }
                }

        // This is how we set up our game board

        /*Method: SetUpGame()
         Method: SetUpGame()
This method sets up the game by:
Creating a list animalEmoji that contains pairs of 8 unique animal emojis (16 total, 8 pairs).
A Random object is used to shuffle and assign emojis to TextBlock elements.
For each TextBlock in the main grid (except for timeTextBlock), an emoji is randomly selected and assigned. Once an emoji is assigned, it's removed from the list to avoid duplicates.
The timer is started, and tenthsOfSecondsElapsed and matchesFound are reset to 0.
         */

        private void SetUpGame()
                {
                    // Here's our list of animal emojis - we have two of each for matching
                    List<string> animalEmoji = new List<string>()
                    {
                        "🐙", "🐙",  // Two octopuses
                        "🐡", "🐡",  // Two pufferfish
                        "🐘", "🐘",  // Two elephants
                        "🐳", "🐳",  // Two whales
                        "🐪", "🐪",  // Two camels
                        "🦕", "🦕",  // Two dinosaurs
                        "🦘", "🦘",  // Two kangaroos
                        "🦔", "🦔",  // Two hedgehogs
                    };

                    // This is like a magic hat that helps us pick emojis randomly
                    Random random = new Random();

                    // We're going through each square on our game board
                    foreach (TextBlock textBlock in mainGrid.Children.OfType<TextBlock>())
                    {
                        // We skip the square that shows the time
                        if (textBlock.Name != "timeTextBlock")
                        {
                            // Make sure we can see the square
                            textBlock.Visibility = Visibility.Visible;

                            // Pick a random number to choose an emoji
                            int index = random.Next(animalEmoji.Count);

                            // Get the emoji we picked
                            string nextEmoji = animalEmoji[index];

                            // Put the emoji on the square
                            textBlock.Text = nextEmoji;

                            // Remove the emoji from our list so we don't pick it again
                            animalEmoji.RemoveAt(index);
                        }
                    }

                    // Start our game clock
                    timer.Start();

                    // Reset our scorekeepers
                    tenthsOfSecondsElapsed = 0;
                    matchesFound = 0;
                }

                // These help us remember which square we clicked and if we're looking for a match
                TextBlock lastTextBlockClicked; // Field - Stores the last TextBlock clicked by the player to compare with the current one.
                bool findingMatch = false;  // Indicates whether the player is trying to find a match for the previously clicked emoji.





        // This happens when we click on a square
        /*
         * Event: TextBlock_MouseDown()
This event is triggered when the user clicks on a TextBlock (an emoji).
It checks whether the player is selecting the first emoji of a pair or trying to match the second one:
First Click (findingMatch = false): The clicked emoji is hidden, stored in lastTextBlockClicked, and the game waits for the second click.
Second Click (findingMatch = true): The code compares the Text of the current and previous clicks.
If they match, both emojis are hidden, and matchesFound is incremented.
If they don’t match, the first emoji is made visible again, and the game resumes.
         */
        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
                {
                    // Figure out which square we clicked
                    TextBlock textBlock = sender as TextBlock;

                    // If we're not already trying to find a match...
                    if (findingMatch == false)
                    {
                        // Hide the emoji we just clicked
                        textBlock.Visibility = Visibility.Hidden;

                        // Remember which square we clicked
                        lastTextBlockClicked = textBlock;

                        // Now we're looking for a match
                        findingMatch = true;
                    }
                    // If we are looking for a match and we found one...
                    else if (textBlock.Text == lastTextBlockClicked.Text)
                    {
                        // Yay! We found a match, so let's count it
                        matchesFound++;

                        // Hide the matching emoji
                        textBlock.Visibility = Visibility.Hidden;

                        // We're done looking for a match
                        findingMatch = false;
                    }
                    // If we're looking for a match but didn't find one...
                    else
                    {
                        // Show the first emoji we clicked again
                        lastTextBlockClicked.Visibility = Visibility.Visible;

                        // We're done looking for a match
                        findingMatch = false;
                    }
                }



        // This happens when we click on the time display
        /* Event: TimeTextBlock_MouseDown()
This event allows the player to restart the game after winning by clicking on the timeTextBlock (which displays the time).
When all 8 matches are found, clicking the timeTextBlock restarts the game by calling SetUpGame().
         */
        private void TimeTextBlock_MouseDown(object sender, MouseButtonEventArgs e)
                {
                    // If we've found all the matches...
                    if (matchesFound == 8)
                    {
                        // Start a new game!
                        SetUpGame();
                    }
                }




            }
}







/*
 * Main Game Flow
Setup: At the start of the game, emojis are randomly placed on TextBlocks in the main grid. The timer begins counting, and the user starts selecting emojis.
Matching Process:
The player clicks an emoji, which becomes hidden.
The player then clicks another emoji.
If they match, both remain hidden, and the game continues.
If they don’t match, the first emoji is revealed again, and the game continues.
Winning Condition: When the player finds all 8 pairs, the timer stops, and a message appears asking if they want to play again.
 * 
 * */

/*Summary: Key Concepts in Code:
DispatcherTimer: A timer specifically for WPF applications. It operates on the UI thread and is ideal for UI updates.
TextBlock Control: Each TextBlock represents a game tile displaying an emoji. The visibility of the TextBlock is changed based on game logic.
Random Number Generation: Used to shuffle emojis, ensuring that they are placed randomly on the grid.
Grid and Children: The mainGrid is assumed to be a Grid in the XAML that holds TextBlock elements, each representing one of the emoji tiles.
This game showcases simple UI interactions using WPF, combined with basic game logic for matching pairs of items.
 * 
 */
