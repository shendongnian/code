            static int guessesleft;
            static Random ran = new Random();
            static int MagicNumber;
            static string UserInput;
    
            static void Main(string[] args)
            {
                ConsoleKeyInfo ci = new ConsoleKeyInfo();
                do
                {
                    guessesleft = 3;
                    UserInput = "";
                    Console.Clear();
                    string username;
                    int guesscount = 1;
                    Console.WriteLine("Welcome to Jackie's Guessing Game!");
                    Console.WriteLine("");
                    Console.WriteLine("Please press any button to continue.");
                    Console.ReadLine();
    
                    Console.WriteLine("What's your name?");
                    username = (Console.ReadLine());
                    //If you're wondering at all, the "You must guess what it is inthree tries." is intentional, since it was showing double-spaced in the command prompt
                    Console.WriteLine("Well, " + username + ", I am thinking of a number from 1 to 10. You must guess what it is inthree tries.");
                    Console.WriteLine("");
                    MagicNumber = ran.Next(1, 11);
    
                    do
                    {
                        
                        Console.WriteLine("Please insert your " + guesscount++ + "º guess!");
                        UserInput = Console.ReadLine().Trim();
                        if (UserInput == MagicNumber.ToString())
                            break;
                       
                        if (Math.Abs(Convert.ToInt32(UserInput) - MagicNumber) < 3)
                            Console.WriteLine("Warm!!");
                        else if(Math.Abs(Convert.ToInt32(UserInput) - MagicNumber) < 2)
                            Console.WriteLine("Hot!!");
    
                        Console.WriteLine("No luck , you have " + --guessesleft + "º guesses left!");
                        Console.WriteLine();
    
                    } while (guesscount < 4);
    
                    if (guesscount == 4)
                        Console.WriteLine("Sorry " + username + " no more tries,you lost!");
                    else
                        Console.WriteLine("Congratulations your guess with number " + UserInput + " is correct,the number was " + MagicNumber);
    
                    Console.WriteLine("Press Q to quit or Enter to Play again!");
                    ci = Console.ReadKey();
                } while (ci.Key != ConsoleKey.Q);  
                
            }
