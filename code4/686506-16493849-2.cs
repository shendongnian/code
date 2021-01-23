        public static IEnumerable<Tuple<T, int>> RunLengthEncode<T>(this IEnumerable<T> sequence)
        {
            T item = default(T); // value never used
            int length = 0;
            foreach (var nextItem in sequence)
            {
                if (length == 0) // first item
                {
                    item = nextItem;
                    length = 1;
                }
                else if (item.Equals(nextItem)) // continuing run
                {
                    length++;
                }
                else // run boundary
                {
                    var run = Tuple.Create(item, length);
                    item = nextItem;
                    length = 1;
                    yield return run;
                }
            }
            if (length > 0) // last run
            {
                yield return Tuple.Create(item, length);
            }
