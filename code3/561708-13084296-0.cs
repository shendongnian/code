    static class Program {
        static void Main()
        {
            var sets = new SetCombiner<int> {
                {1,2},{3,4},{2,4},{9,10},{9,12}
            };
            sets.Combine();
            foreach (var set in sets)
            {
                Console.WriteLine("{" +
                    string.Join(",", set.OrderBy(x => x)) + "}");
            }
        }
    }
    
    class SetCombiner<T> : List<HashSet<T>>
    {
        public void Add(params T[] values)
        {
            Add(new HashSet<T>(values));
        }
        public void Combine()
        {
            int priorCount;
            do
            {
                priorCount = this.Count;
                for (int i = Count - 1; i >= 0; i--)
                {
                    if (i >= Count) continue; // watch we haven't removed
                    int formed = i;
                    for (int j = formed - 1; j >= 0; j--)
                    {
                        if (this[formed].Any(this[j].Contains))
                        { // an intersection exists; merge and remove
                            this[j].UnionWith(this[formed]);
                            this.RemoveAt(formed);
                            formed = j;
                        }
                    }
                }
            } while (priorCount != this.Count); // making progress
        }
    }
