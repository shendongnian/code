        public static IEnumerable<IEnumerable<T>> Permute<T>(this IEnumerable<T> list)
        {
            for (int i = (1 << list.Count()) - 1; i >= 0; i--)
                yield return list.BitWhere(i);
        }
        public static IEnumerable<T> BitWhere<T>(this IEnumerable<T> list, int selector)
        {
            BitVector32 bits = new BitVector32(selector);
            int c = list.Count();
            for (int i = 1; i <= c; i++)
            {
                if (bits[1 << (c - i)])
                    yield return list.ElementAt(i - 1);
            }
        }
