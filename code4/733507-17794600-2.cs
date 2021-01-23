        public static int? FirstBetween<T>(this List<T> list, T val) where T : IComparable
        {
            if (list != null && !ReferenceEquals(val, null))
            {
                bool greater = false;
                for (int i = 1; i < list.Count; i++)
                {
                    var lastGreater = i == 1 ? (list[i-1].CompareTo(val) > 0) : greater;
                    greater = list[i].CompareTo(val) > 0;
                    if (!lastGreater && greater)
                        return i;
                }
            }
            return null;
        }
