    using System.Collections.Generic;
    
    namespace System.Linq
    {
        public static class IEnumerableExtensions
        {
            enum SortDirection
            {
                Ascending,
                Descending
            }
    
            public static IOrderedEnumerable<T> OrderBy<T>
                (this IEnumerable<T> items,
                string propertyName)
            {
                var propInfo = typeof (T).GetProperty(propertyName);
                return items.OrderByDirection(x => propInfo.GetValue(x, null), SortDirection.Ascending);
            }
    
            public static IOrderedEnumerable<T> ThenBy<T>
                (this IOrderedEnumerable<T> items,
                string propertyName)
            {
                var propInfo = typeof(T).GetProperty(propertyName);
                return items.ThenByDirection(x => propInfo.GetValue(x, null), SortDirection.Ascending);
            }
    
            public static IOrderedEnumerable<T> OrderByDescending<T>
                (this IEnumerable<T> items,
                string propertyName)
            {
                var propInfo = typeof(T).GetProperty(propertyName);
                return items.OrderByDirection(x => propInfo.GetValue(x, null), SortDirection.Descending);
            }
    
            public static IOrderedEnumerable<T> ThenByDescending<T>
                (this IOrderedEnumerable<T> items,
                string propertyName)
            {
                var propInfo = typeof(T).GetProperty(propertyName);
                return items.ThenByDirection(x => propInfo.GetValue(x, null), SortDirection.Descending);
            }
    
            private static IOrderedEnumerable<T> OrderByDirection<T, TKey>
                (this IEnumerable<T> items,
                Func<T, TKey> keyExpression,
                SortDirection sortDirection)
            {
                switch (sortDirection)
                {
                    case SortDirection.Ascending:
                        return items.OrderBy(keyExpression);
                    case SortDirection.Descending:
                        return items.OrderByDescending(keyExpression);
                }
                throw new ArgumentException("Unknown SortDirection: " + sortDirection);
            }
    
            private static IOrderedEnumerable<T> ThenByDirection<T, TKey>
                (this IOrderedEnumerable<T> items,
                    Func<T, TKey> keyExpression,
                    SortDirection sortDirection)
            {
                switch (sortDirection)
                {
                    case SortDirection.Ascending:
                        return items.ThenBy(keyExpression);
                    case SortDirection.Descending:
                        return items.ThenByDescending(keyExpression);
                }
                throw new ArgumentException("Unknown SortDirection: " + sortDirection);
            }
        }
    }
