        public static IEnumerable<T[]> IterateOverLists<T>(this IList<IEnumerable<T>> lists )
        {
            var array = new T[lists.Count];
            return IterateOverLists( lists, array, 0 );
        }
        private static IEnumerable<T[]> IterateOverLists<T>(this IList<IEnumerable<T>> lists, T[] array, int index)
        {
            foreach (var value in lists[index])
            {
                array[index] = value;
                if (index == lists.Count - 1)
                {
                    // can make a copy of the array here too...
                    yield return array;
                }
                else
                {
                    foreach (var item in IterateOverLists(lists, array, index + 1))
                    {
                        yield return item;
                    }
                }
            }
        }
