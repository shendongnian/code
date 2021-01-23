    List<int> list = new List<int> { 1, 2, 3, 4, 5, 6, 7 };
                Console.WriteLine("Original List");
                foreach (int i in list)
                {
                    Console.Write(i + ",");
                }
                Console.WriteLine(Environment.NewLine + "Move Index 2 Down");
                list.Move(2);
                foreach (int i in list)
                {
                    Console.Write(i + ",");
                }
                Console.WriteLine(Environment.NewLine + "Move Index 3 Up");
                list.Move(3, false);
                foreach (int i in list)
                {
                    Console.Write(i + ",");
                }
