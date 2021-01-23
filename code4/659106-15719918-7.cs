       IEnumerable<T> NonRecursiveEnumerator<T>( IEnumerable root ) {
            Stack<IEnumerable> Queue = new Stack<IEnumerable>( );
            Stack.Push( root );
            do {
                root = Queue.Pop( );
                foreach (var item in root) {
                    if (item is T) yield return (T)item;
                    if (item is IEnumerable) Queue.Push( (IEnumerable) item );
                }
            } while ( Queue.Count>0);
            yield break;
        }
