    public static class MultidimensionalArrayExtensions
    {
        /// <summary>
        /// Projects each element of a sequence into a new form by incorporating the element's index.
        /// </summary>
        /// <typeparam name="T">The type of the elements of the array.</typeparam>
        /// <param name="array">A sequence of values to invoke the action on.</param>
        /// <param name="action">An action to apply to each source element; the second parameter of the function represents the index of the source element.</param>
        public static void ForEach<T>(this Array array, Action<T, int[]> action)
        {
            var dimensionSizes = Enumerable.Range(0, array.Rank).Select(i => array.GetLength(i)).ToArray();
            ArrayForEach(dimensionSizes, action, new int[] { }, array);
        }
        private static void ArrayForEach<T>(int[] dimensionSizes, Action<T, int[]> action, int[] externalCoordinates, Array masterArray)
        {
            if (dimensionSizes.Length == 1)
                for (int i = 0; i < dimensionSizes[0]; i++)
                {
                    var globalCoordinates = externalCoordinates.Concat(new[] { i }).ToArray();
                    var value = (T)masterArray.GetValue(globalCoordinates);
                    action(value, globalCoordinates);
                }
            else
                for (int i = 0; i < dimensionSizes[0]; i++)
                    ArrayForEach(dimensionSizes.Skip(1).ToArray(), action, externalCoordinates.Concat(new[] { i }).ToArray(), masterArray);
        }
        
        public static void PopulateArray<T>(this Array array, Func<int[], T> calculateElement)
        {
            array.ForEach<T>((element, indexArray) => array.SetValue(calculateElement(indexArray), indexArray));
        }
    }
