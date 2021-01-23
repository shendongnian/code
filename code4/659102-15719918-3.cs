       IEnumerable<T> NonRecursiveEnumerator<T>( IEnumerable root ) {
            Queue<IEnumerable> Queue = new Queue<IEnumerable>( );
            Queue.Enqueue( root );
            do {
                root = Queue.Dequeue( );
                foreach (var item in root) {
                    if (item is T) yield return (T)item;
                    else if (item is IEnumerable) Queue.Enqueue( (IEnumerable) item );
                }
            } while ( Queue.Count>0);
            yield break;
        }
