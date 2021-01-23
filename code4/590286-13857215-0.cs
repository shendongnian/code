    public void Menu()
        {
            var list = new CreateList();
            var menuStationaryItems = menuStationaryItems();
            short curSelectMenuItem = 0, selectMenuSelected; 
            var cki = new ConsoleKeyInfo();
            const string listborder = "-*************************-";
            const string nolistitems = "You don't have anything in the list.";
            const string selectleftarrow = "-->";
            const string selectrightarrow = "<--";
            list.ListData();
            do
            {
                if (Program.list.Count == 0)
                {
                    Console.Clear();
                    Console.WriteLine();
                    Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (listborder.Length / 2)) + "}", listborder);
                    Console.WriteLine();
                    Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (nolistitems.Length / 2)) + "}", nolistitems);
                    Console.WriteLine();
                    Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (listborder.Length / 2)) + "}", listborder);
                    Console.WriteLine();
                    Thread.Sleep(4000);
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (listborder.Length / 2)) + "}", listborder);
                    Console.WriteLine();
                    foreach (var itemin Program.list)
                    {
                        Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (menuStationaryItems[0].Length / 2)) + "}{1}", menuStationaryItems[0], item.name);
                        Console.WriteLine();
                    }
                    Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (listborder.Length / 2)) + "}", listborder);
                    Console.WriteLine();
                    for (selectMenuSelected = 0; selectMenuSelected < Program.list.Count; selectMenuSelected++)
                    {
                        if (curSelectMenuItem == selectMenuSelected)
                        {
                            Console.WriteLine("{0," + (Console.WindowWidth / 2) + "}{1}{2}"
                                , selectleftarrow, Program.list[selectMenuSelected].name, selectrightarrow);
                        }
                        else
                        {
                            Console.WriteLine("{0," + (Console.WindowWidth / 2) + "}", Program.list[selectMenuSelected].name);
                        }
                    }
                    cki = Console.ReadKey(true);
                    if (cki.Key == ConsoleKey.DownArrow)
                    {
                        curSelectMenuItem++;
                        if (curSelectMenuItem > Program.list.Count - 1) curSelectMenuItem = 0;
                    }
                    else if (cki.Key == ConsoleKey.UpArrow)
                    {
                        curSelectMenuItem--;
                        if (curSelectMenuItem < 0) curSelectMenuItem = Convert.ToInt16(Program.list.Count - 1);
                    }
                    for (var i = 0; i < Program.list.Count; i++)
                    {
                        if ((cki.Key == ConsoleKey.Enter && curSelectMenuItem == i))
                        {
                            variable = Program.list[curSelectMenuItem].name;
                        }
                    }
                }
            } while (cki.Key != ConsoleKey.Enter);
        }
