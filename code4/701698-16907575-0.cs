    class Program
    {
        public enum Direction
        {
            Up, 
            Down, 
            Right, 
            Left
        }
        static void Main(string[] args)
        {
            const int delay = 75;
            string snake = "O";
            char border = 'X';
            int x, y;
            int length;
            bool crashed = false;
            Direction curDirection = Direction.Up;
            Dictionary<string, bool> eaten = new Dictionary<string, bool>();
            Console.CursorVisible = false;
            ConsoleKeyInfo cki;
            bool quit = false;
            while (!quit)
            {
                Console.Clear();
                Console.Title = "Use 'a', 's', 'd' and 'w' to steer.  Hit 'q' to quit.";
                // draw border around the console:
                string row = new String(border, Console.WindowWidth);
                Console.SetCursorPosition(0, 0);
                Console.Write(row);
                Console.SetCursorPosition(0, Console.WindowHeight - 2);
                Console.Write(row);
                for (int borderY = 0; borderY < Console.WindowHeight - 2; borderY++)
                {
                    Console.SetCursorPosition(0, borderY);
                    Console.Write(border.ToString());
                    Console.SetCursorPosition(Console.WindowWidth - 1, borderY);
                    Console.Write(border.ToString());
                }
                // reset all game variables:
                length = 1;
                crashed = false;
                curDirection = Direction.Up;
                eaten.Clear();
                x = Console.WindowWidth / 2;
                y = Console.WindowHeight / 2;
                eaten.Add(x.ToString("00") + y.ToString("00"), true);
                // draw new snake:
                Console.SetCursorPosition(x, y);
                Console.Write(snake);
    
                // wait for initial keypress:
                while (!Console.KeyAvailable)
                {
                    System.Threading.Thread.Sleep(10);
                }
                // see if intitial direction should be changed:
                cki = Console.ReadKey(true);
                switch (cki.KeyChar)
                {
                    case 'w':
                        curDirection = Direction.Up;
                        break;
                    case 's':
                        curDirection = Direction.Down;
                        break;
                    case 'a':
                        curDirection = Direction.Left;
                        break;
                    case 'd':
                        curDirection = Direction.Right;
                        break;
                    case 'q':
                        quit = true;
                        break;
                }
                // main game loop:
                DateTime nextCheck = DateTime.Now.AddMilliseconds(delay);
                while (!quit && !crashed)
                {
                    Console.Title = "Length: " + length.ToString();
                    // consume keystrokes and change current direction until the delay has expired:
                    // *The snake won't actually move until after the delay!
                    while (nextCheck > DateTime.Now)
                    {
                        if (Console.KeyAvailable)
                        {
                            cki = Console.ReadKey(true);
                            switch (cki.KeyChar)
                            {
                                case 'w':
                                    curDirection = Direction.Up;
                                    break;
                                case 's':
                                    curDirection = Direction.Down;
                                    break;
                                case 'a':
                                    curDirection = Direction.Left;
                                    break;
                                case 'd':
                                    curDirection = Direction.Right;
                                    break;
                                case 'q':
                                    quit = true;
                                    break;
                            }
                        }
                    }
                    // if the user didn't quit, attempt to move without hitting the border:
                    if (!quit)
                    {
                        string key = "";
                        switch (curDirection)
                        {
                            case Direction.Up:
                                if (y > 1)
                                {
                                    y--;
                                }
                                else
                                {
                                    crashed = true;
                                }
                                break;
                            case Direction.Down:
                                if (y < Console.WindowHeight - 3)
                                {
                                    y++;
                                }
                                else
                                {
                                    crashed = true;
                                }
                                break;
                            case Direction.Left:
                                if (x > 1)
                                {
                                    x--;
                                }
                                else
                                {
                                    crashed = true;
                                }
                                break;
                            case Direction.Right:
                                if (x < Console.WindowWidth - 2)
                                {
                                    x++;
                                }
                                else
                                {
                                    crashed = true;
                                }
                                break;
                        }
                        // if the user didn't hit the border, see if they hit the snake
                        if (!crashed)
                        {
                            key = x.ToString("00") + y.ToString("00");
                            if (!eaten.ContainsKey(key))
                            {
                                length++;
                                eaten.Add(key, true);
                                Console.SetCursorPosition(x, y);
                                Console.Write(snake);
                            }
                            else
                            {
                                crashed = true;
                            }
                        }
                        // set the next delay:
                        nextCheck = DateTime.Now.AddMilliseconds(delay);
                    }
                } // end main game loop
                if (crashed)
                {
                    Console.Title = "*** Crashed! *** Length: " + length.ToString() + "     Hit 'q' to quit, or 'r' to retry!";
                    // wait for quit or retry:
                    bool retry = false;
                    while (!quit && !retry)
                    {
                        if (Console.KeyAvailable)
                        {
                            cki = Console.ReadKey(true);
                            switch (cki.KeyChar)
                            {
                                case 'q':
                                    quit = true;
                                    break;
                                case 'r':
                                    retry = true;
                                    break;
                            }
                        }
                    }
                } 
            } // end main program loop
        } // end Main()
    }
