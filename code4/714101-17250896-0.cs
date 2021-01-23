       public static IEnumerable<T> Sort<T>(this IEnumerable<T> list,
                string column, SortDirection direction = SortDirection.Ascending)
       {
            Func<T, object> selector = p => p.GetType().GetProperty(column).GetValue(p, null);
            return (direction == SortDirection.Ascending
                        ? list.OrderBy(selector)
                        : list.OrderByDescending(selector)
                        );
       }
