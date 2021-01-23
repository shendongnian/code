        public static int? FirstBetween<T>(this List<T> list, T val) where T : IComparable
        {
            if (list != null && !ReferenceEquals(val, null))
            {
                for (int i = 1; i < list.Count; i++)
                    if (list[i - 1].CompareTo(val) < 0 && list[i].CompareTo(val) > 0)
                        return i;
            }
            return null;
        }
