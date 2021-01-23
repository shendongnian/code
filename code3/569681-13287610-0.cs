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
            Stack<EPair<T>> epairs = new Stack<EPair<T>>(ins.Select(i =>
                new EPair<T> { able = i, ator = i.GetEnumerator() }));
            foreach (var e in epairs)
            {
                if (!e.ator.MoveNext())
                {
                    // One input is empty, so there is no output.
                    foreach (var ee in epairs)
                        ee.ator.Dispose();
                    yield break;
                }
            }
            while (true)
            {
                // Return current state.
                yield return epairs.Select(ep => ep.ator.Current).ToArray();
                // Find an iterator to increment and do so.
                Stack<EPair<T>> popped = new Stack<EPair<T>>();
                bool incremented = false;
                while (epairs.Count > 0)
                {
                    var p = epairs.Pop();
                    if (p.ator.MoveNext())
                    {
                        incremented = true;
                        epairs.Push(p);
                        while (popped.Count > 0)
                            epairs.Push(popped.Pop());
                        // Found an iterator to increment.
                        break;
                    }
                    else
                    {
                        // This iterator is finished so restart it.
                        p.ator.Dispose();
                        p.ator = p.able.GetEnumerator();
                        p.ator.MoveNext();
                        popped.Push(p);
                    }
                }
                if (!incremented)
                {
                    // All of our iterators are finished.
                    foreach (var ee in epairs)
                        ee.ator.Dispose();
                    yield break;
                }
            }
        }
    }
