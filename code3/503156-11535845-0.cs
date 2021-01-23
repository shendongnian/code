    public static List<T> ToListOf<T>(this IEnumerable enumerable)
            {
                var list = new List<T>();
    
                foreach (var item in enumerable)
                {
                    list.Add(item.ConvertTo<T>());
                }
    
                return list;
            }
