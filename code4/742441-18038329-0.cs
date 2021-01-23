    public static class CollectionExtension
    {
        public static bool SequenceContain<T>(this IEnumerable<T> target, IEnumerable<T> that)
        {
            var targetEnumerater = target.GetEnumerator();
            var thatEnumerater = that.GetEnumerator();
            var thatHasValue = thatEnumerater.MoveNext();
            var targetHasValue = targetEnumerater.MoveNext();
            var matchCount = 0;
            try
            {
                while (thatHasValue && targetHasValue)
                {
                    if (!EqualityComparer<T>.Default.Equals(targetEnumerater.Current, thatEnumerater.Current))
                    {
                        if (matchCount > 0)
                        {
                            thatEnumerater.Reset();
                            thatEnumerater.MoveNext();
                            matchCount = 0;
                        }
                        targetHasValue = targetEnumerater.MoveNext();
                        continue;
                    }
                    targetHasValue = targetEnumerater.MoveNext();
                    thatHasValue = thatEnumerater.MoveNext();
                    matchCount++;
                }
                return matchCount == that.Count();
            }
            finally
            {
                thatEnumerater.Dispose();
                targetEnumerater.Dispose();
            }
        }
    }
