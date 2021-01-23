        static void Main(string[] args)
        {
            string[] files = Directory.GetFiles(@"C:\");
            foreach (string file in files)
            {
                Console.WriteLine(file);
            }
            Console.SetCursorPosition(0, 0); //setting initial place of cursor
            int curPos = -1;
            if (files.Length > 0)
            {
                curPos = 0;
            }
            ConsoleKeyInfo keyinfo;
            while ((keyinfo = Console.ReadKey(true)).Key != ConsoleKey.Escape)  //untill i press escape
            {
                switch (keyinfo.Key)
                {
                    case ConsoleKey.DownArrow:   //for Down key
                        curPos++;
                        
                            // Here's the problem, the cursor goes to the end of the list, 
                            // not moving through each item:
                        Console.SetCursorPosition(0, curPos);
                            
                        
                        break;
                    case ConsoleKey.UpArrow:
                        curPos--;
                        Console.SetCursorPosition(0, curPos);
                        break;
                }
            }
            
        }
