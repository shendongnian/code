    class Program
    {
        static int Score = 0;
        static int Chances = 10;
        static int promptX, promptY;
        static string board = "{No Board Loaded}";
        static System.Diagnostics.Stopwatch SW = new Stopwatch();
        static void Main(string[] args)
        {
            ConsoleKeyInfo cki;
            Console.Title = "Some Word Game";
            bool quit = false;
            bool gameWon = false;
            bool gameOver = false;
            
            while (!quit)
            {
                Reset();
                ShowBoard("C _ _ E _ _ _ T _ _ N");
                gameWon = false;
                gameOver = false;
                while (!gameOver)
                {
                    UpdateStats();
                    // make it appear as though the cursor is waiting after the prompt:
                    Console.SetCursorPosition(promptX, promptY);
                    if (Console.KeyAvailable)
                    {
                        cki = Console.ReadKey(true); // don't display key
                        if (cki.Key == ConsoleKey.Escape)
                        {
                            gameOver = true;
                        }
                        else
                        {
                            // if it's A thru Z...
                            if (char.IsLetter(cki.KeyChar)) 
                            {
                                string key = cki.KeyChar.ToString().ToUpper();
                                Console.Write(key);
                                switch (key)
                                {
                                    case "E":
                                        Score += 10;
                                        Chances--;
                                        break;
                                    case "L":
                                        Score += 10;
                                        Chances--;
                                        break;
                                    case "B":
                                        Score += 10;
                                        Chances--;
                                        break;
                                    case "R":
                                        Score += 10;
                                        Chances--;
                                        break;
                                    case "A":
                                        Score += 10;
                                        Chances--;
                                        break;
                                    case "I":
                                        Score += 10;
                                        Chances--;
                                        break;
                                    case "O":
                                        Score += 10;
                                        Chances--;
                                        break;
                                    default:
                                        Score += 0;
                                        Chances--;
                                        break;
                                }
                                // ... possibly update the board somehow in here? ... 
                                // ... some board logic ...
                                // ShowBoard("updated board in here");
                                // set gameOver to drop out of loop
                                // also set gameWon if the user beat the board
                            }
                            else
                            {
                                Console.Write(" ");
                            }
                        }
                    }
                    System.Threading.Thread.Sleep(200);
                }
                if (gameWon)
                {
                    // ... do something ...
                }
                else
                {
                    // ... do something else ...
                }
                quit = QuitProgram();
            }
        }
        static void Reset()
        {
            // reset game variables and clock:
            Score = 0;
            Chances = 10;
            SW.Restart();
            Console.Clear();
            CenterPrompt("Guess: ");
            promptX = Console.CursorLeft;
            promptY = Console.CursorTop;
        }
        static void ShowBoard(string NewBoard)
        {
            board = NewBoard;
            Console.SetCursorPosition(Console.WindowWidth / 2 - board.Length / 2, promptY - 2);
            Console.Write(board);
        }
        static void UpdateStats()
        {
            // hide cursor while we update the stats:
            Console.CursorVisible = false;
            Console.SetCursorPosition(0, 0);
            Console.Write("Score: " + Score.ToString("000"));
            Console.SetCursorPosition(35, 0);
            Console.Write("Chances: " + Chances.ToString("00"));
            TimeSpan ts = SW.Elapsed;
            string totalTime = String.Format("Time Elapsed: {0}:{1}:{2}", ts.Hours, ts.Minutes.ToString("00"), ts.Seconds.ToString("00"));
            Console.SetCursorPosition(Console.WindowWidth - totalTime.Length, 0);
            Console.Write(totalTime);
            // ... add other output statistics in here? ...
            // turn cursor back on for the prompt:
            Console.CursorVisible = true;
        }
        static void CenterPrompt(string message)
        {
            Console.SetCursorPosition(Console.WindowWidth / 2 - message.Length / 2, Console.WindowHeight / 2);
            Console.Write(message);
        }
        static bool QuitProgram()
        {
            Console.Clear();
            CenterPrompt("Thanks for playing! Press 'q' to Quit, or 'r' to Retry.");
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo cki = Console.ReadKey(true);
                    switch (cki.KeyChar.ToString().ToUpper())
                    {
                        case "Q":
                            return true;
                        case "R":
                            return false;
                    }
                }
            }
        }
    }
