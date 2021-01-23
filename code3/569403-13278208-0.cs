        public static T[,] ToMultidimensionArray<T>(this List<T[]> list, int columns)
        {
            var array = new T[list.Count, columns];
            for (int i = 0; i < list.Count; i++)
            {
                var source = list[i];
                for (int j = 0; j < columns; j++)
                {
                    array[i, j] = source[j];
                }
            }
            return array;
        }
