        public static IEnumerable<IEnumerable<T>> Split<T>(this IEnumerable<T> source, int blockSize)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            if (blockSize <= 0)
                throw new ArgumentException("blockSize = {0}".FormatWith(blockSize), "blockSize");
            var result = new List<IEnumerable<T>>();
            for (int blockStartIndex = 0; blockStartIndex < source.Count(); blockStartIndex += blockSize)
            {
                int blockStart = blockStartIndex;
                int blockEnd = blockStartIndex + blockSize - 1;
                IEnumerable<T> block = source.Where((x, i) => i >= blockStart && i <= blockEnd);
                result.Add(block);
            }
            return result;
        }
