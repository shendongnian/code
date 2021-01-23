        public static void SetAll<T>(this Array array, T value)
        {
            var sizes = new int[array.Rank];
            sizes[array.Rank - 1] = 1;
            for (var d = array.Rank - 2; d >= 0; d--)
            {
                sizes[d] = (array.GetUpperBound(d + 1) + 1)*sizes[d + 1];
            }
            for (var i = 0; i < array.Length; i++)
            {
                var remainder = i;
                var index = new int[array.Rank];
                for (var d = 0; d < array.Rank && remainder > 0; d++)
                {
                    index[d] = remainder / sizes[d];
                    remainder -= index[d]*sizes[d];
                }
                array.SetValue(value, index);
            }
        }
