        static void Main(string[] args)
        {
            SortedSet<string> set = new SortedSet<string>();
            set.Add("One");
            set.Add("Two");
            set.Add("Three");
            string first = set.First();
            set.Remove(first);
            foreach (var s in set)
            {
                Console.WriteLine(s);                
            }
            Console.ReadLine();
        }
