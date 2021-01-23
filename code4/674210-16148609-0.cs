    childOrg.Users = users.ExceptBy(selectedUsers, u=>u.UserId)
---
    public static class MyExtensions
    {
        public static IEnumerable<T> ExceptBy<T, TKey>(
            this IEnumerable<T> list1,
            IEnumerable<T> list2,
            Func<T, TKey> keySelector)
        {
            HashSet<TKey> knownKeys = new HashSet<TKey>(list2.Select(x => keySelector(x)));
            return list1.Where(x => knownKeys.Add(keySelector(x)));
        }
    }
