    public static class Extensions
    {
        // Keeps track of an iterator and its source enumerable.
        private class EPair<T>
        {
            public IEnumerable<T> able { get; set; }
            public IEnumerator<T> ator { get; set; }
        }
        public static IEnumerable<IEnumerable<T>> Permutations<T>(
            this IEnumerable<IEnumerable<T>> ins)
        {
            List<EPair<T>> epairs = new List<EPair<T>>(ins.Select(i =>
                new EPair<T> { able = i, ator = i.GetEnumerator() }));
            bool incremented = true;
            foreach (var e in epairs)
            {
                if (!e.ator.MoveNext())
                {
                    incremented = false; // this will skip to the end
                    break;
                }
            }
            while (incremented)
            {
                // Return current state.
                yield return epairs.Select(ep => ep.ator.Current).ToArray();
                incremented = false;
                for (int i = epairs.Count - 1; i >= 0 && !incremented; i--)
                {
                    var tryToIncrement = epairs[i];
                    if (tryToIncrement.ator.MoveNext())
                        incremented = true;
                    else
                    {
                        tryToIncrement.ator.Dispose();
                        tryToIncrement.ator = epairs[i].able.GetEnumerator();
                        tryToIncrement.ator.MoveNext();
                    }
                }
            }
            // All of our iterators are finished.
            foreach (var ee in epairs)
                ee.ator.Dispose();
        }
    }
