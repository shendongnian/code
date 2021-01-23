        // For separating a collection into ranges
        static List<List<T>> Split<T>(List<T> source, int size)
        {
            // TODO: Prepopulate with the right capacity
            List<List<T>> ret = new List<List<T>>();
            for (int i = 0; i < source.Count; i += size)
            {
                ret.Add(source.GetRange(i, Math.Min(size, source.Count - i)));
            }
            return ret;
        }
        // For separating an int into a Tuple range
        static List<Tuple<int, int>> Split(int source, int size)
        {
            var ret = new List<Tuple<int, int>>();
            for (int i = 0; i < source; i += size)
            {
                ret.Add(new Tuple<int, int>(i, (i + Math.Min(size, source - i))));
            }
            return ret;
        }
