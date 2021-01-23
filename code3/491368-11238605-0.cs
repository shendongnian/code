            SortedList<string, string> sorted = new SortedList<string, string>();
            foreach (string s in sorted.Keys)
                Console.WriteLine(s);
            IEnumerable stillSorted = sorted as IEnumerable;
            foreaach (string t in stillSorted.Keys)
                Console.WriteLine(t);
