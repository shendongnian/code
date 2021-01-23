    static void Main(string[] args)
            {
                string[] myValues = new[] { "1", "2", "3", "4" };
                Stack back = new Stack();
                Stack forward = new Stack();
                int maxPos = myValues.Length - 1;
                int minPos = 0;
                int currPos = myValues.Length - 1;
                Console.WriteLine("Initial Navigation Values {0}", string.Join(",", myValues));
                Console.WriteLine("User <- or -> keys to navigate between the values");
                Console.WriteLine("You are on Node 4");
                var key = Console.ReadKey().Key;
                while (key == ConsoleKey.LeftArrow || key == ConsoleKey.RightArrow)
                {
                    if (currPos == minPos && key == ConsoleKey.LeftArrow)
                    {
                        Console.WriteLine("You cannot navigate back anymore");
                        key = Console.ReadKey().Key;
                        continue;
                    }
                    if (currPos == maxPos && key == ConsoleKey.RightArrow)
                    {
                        Console.WriteLine("You cannot navigate forward anymore");
                        key = Console.ReadKey().Key;
                        continue;
                    }
                    if (key == ConsoleKey.LeftArrow)
                    {
                        forward.Push(myValues[currPos]);
                        currPos -= 1;
                    }
                    if (key == ConsoleKey.RightArrow)
                    {
                        back.Push(forward.Pop());
                        currPos += 1;
                    }
                    Console.WriteLine("You are on Node {0}", myValues[currPos]);
                    key = Console.ReadKey().Key;
                }
            }
