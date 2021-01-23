    public static class Extensions
    {
        public static IEnumerable<T> TryForEach<T>(this IEnumerable<T> sequence, Action<Exception> handler)
        {
            if (sequence == null)
            {
                throw new ArgumentNullException("sequence");
            }
            if (handler == null)
            {
                throw new ArgumentNullException("handler");
            }
            var mover = sequence.GetEnumerator();
            bool more;
            try
            {
                more = mover.MoveNext();
            }
            catch (Exception e)
            {
                handler(e);
                yield break;
            }
            while (more)
            {
                yield return mover.Current;
                try
                {
                    more = mover.MoveNext();
                }
                catch (Exception e)
                {
                    handler(e);
                    yield break;
                }
            }
        }
    }
