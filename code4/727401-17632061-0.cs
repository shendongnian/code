        public static void RemoveWhere<T>(this List<T> list, Predicate<T> predicate)
        {
            foreach (var ele in list)
            {
                if (predicate(ele))
                    list.Remove(ele);
            }
        }
