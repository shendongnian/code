            int fooCursorTop = Console.CursorTop + 1;
            var timer2 = new System.Timers.Timer(1000);
            timer2.Elapsed += new System.Timers.ElapsedEventHandler(delegate
                {
                    int tempCursorLeft = Console.CursorLeft;
                    int tempCursorTop = Console.CursorTop;
                    Console.CursorLeft = 0;
                    Console.CursorTop = fooCursorTop;
                    Console.WriteLine("Foo");
                    Console.CursorLeft = tempCursorLeft;
                    Console.CursorTop = tempCursorTop;
                    fooCursorTop++;
                });
            timer2.Start();
            string input = string.Empty;
            while (input != "quit")
            {
                input = Console.ReadLine();
                Console.CursorTop = fooCursorTop;
                Console.WriteLine(input);
                fooCursorTop += 2;
            }
