      SortedList<int, string> x = new SortedList<int, string>();
            x.Add(4, "BCD");
            x.Add(6, "BCD");
            x.AddNext("a");
            x.AddNext("b");
            x.AddNext("c");
            x.AddNext("d");
            x.AddNext("e");
            foreach (var item in x)
                Console.WriteLine(item.Key + " " + item.Value);
