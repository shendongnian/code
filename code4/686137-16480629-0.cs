    list.Do(d => d.Value += 1000); 
---
    public static partial class  Extensions
    {
        public static void Do<T>(this IEnumerable<T> e, Action<T> action)
        {
            foreach(var item in e)
                action(item);
        }
    }
