            Dictionary<int, string> x = new Dictionary<int, string>();
            x.Add(1, "a");
            x.Add(2, "a");
            x.Add(3, "a");
            x.Add(4, "a");
            x.Add(8, "a");
            Console.WriteLine((x.Keys.Where(k => !x.Keys.Contains(k + 1)).Min() + 1).ToString());
