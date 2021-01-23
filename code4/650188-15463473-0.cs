    while (true)
            {
                var ch = Console.ReadKey(false).Key;
                switch (ch)
                {
                    case ConsoleKey.UpArrow:
                        HighlightStartGame();
                        break;
                    case ConsoleKey.DownArrow:
                        HighlightEndGame();
                        break;
                }
            }
    static void HighlightStartGame()
        {
            Console.Clear();
            Console.ResetColor();
            StartGame.isChecked = true;
            Console.WriteLine(StartGame);
            EndGame.isChecked = false;
            Console.WriteLine(EndGame);
            
        }
        static void HighlightEndGame()
        {
            Console.Clear();
            Console.ResetColor();
            StartGame.isChecked = false;
            Console.WriteLine(StartGame);
            EndGame.isChecked = true;
            Console.WriteLine(EndGame);
        }
