     public static IEnumerable<T> Flatten<T>(
            this IEnumerable<T> items,
            Func<T, IEnumerable<T>> getChilds)
     {
         var stack = new Stack<T>();
         foreach(var item in items)
             stack.Push(item);
         while(stack.Count > 0)
         {
             var current = stack.Pop();
             yield return current;
             foreach(var child in getChilds(current))
                 stack.Push(child);
         }
     }
