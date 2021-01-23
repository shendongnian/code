    static IEnumerable<T> RecursiveEnumerator<T>( IEnumerable root ) {
         if (root is T) yield return (T)root;
         foreach (var item in root) {
             if (item is IEnumerable) {
                 foreach (var result in RecursiveEnumerator<T>( (IEnumerable)item )) {
                     yield return result;
                 }
             } else {
                  if (item is T) yield return (T)item;
             }
         }
         yield break;
     }
    
     static IEnumerable<T> NonRecursiveEnumerator<T>( T root ) {
         Stack<T> Stack = new Stack<T>( );
         Stack.Push( root );
                    
         do {
             root = Stack.Pop( );
             if (root is T) yield return (T)root;          
             if (root is IEnumerable)
                foreach (var item in ((IEnumerable<T>) root).Reverse()) 
                   Stack.Push(item);
         } while (Stack.Count > 0);
         yield break;
      }
