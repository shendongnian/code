	public static partial class EnumExts
	{
        /// <summary>Split sequence into blocks of specified size.</summary>
        /// <typeparam name="T">Type of items in sequence</typeparam>
        /// <param name="sequence"><see cref="IEnumerable{T}"/> sequence to split</param>
        /// <param name="batchLength">Number of items per returned array</param>
        /// <returns>Arrays of <paramref name="batchLength"/> items, with last array smaller if sequence count is not a multiple of <paramref name="batchLength"/></returns>
        public static IEnumerable<T[]> Batch<T>(this IEnumerable<T> sequence, int batchLength)
        {
            if (sequence == null)
                throw new ArgumentNullException("sequence");
            if (batchLength < 2)
                throw new ArgumentException("Batch length must be at least 2", "batchLength");
            using (var iter = sequence.GetEnumerator())
            {
                var bfr = new T[batchLength];
                while (true)
                {
                    for (int i = 0; i < batchLength; i++)
                    {
                        if (!iter.MoveNext())
                        {
                            if (i == 0)
                                yield break;
                            Array.Resize(ref bfr, i);
                            break;
                        }
                        bfr[i] = iter.Current;
                    }
                    yield return bfr;
                    bfr = new T[batchLength];
                }
            }
        }
	}
