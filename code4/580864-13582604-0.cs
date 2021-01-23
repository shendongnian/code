            string[] id1 = { "abc" };
            string[] id2 = { "def", "abc", "okl" };
            IEnumerable<string> both = id2.Union(id1);
            foreach (string id in both)
                Console.WriteLine(id);
