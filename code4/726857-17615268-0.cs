            public static List<int> a = new List<int>();
            public static List<List<int>> list = new List<List<int>>();
    
            for (int i = 0; i < 5; i++)
                a.Add(i);
            list.Add(a.Select(i => i).ToList());//passed in a copy of a.
            Console.WriteLine(list[0].Count); // **count = 5**
            a.RemoveAt(0);
            list.Add(a);
            Console.WriteLine(list[0].Count); // **count = 5** 
            Console.WriteLine(list[1].Count); // count = 4
