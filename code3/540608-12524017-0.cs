        public IEnumerable<T> TryForEach<T>(IEnumerable<T> list, Action executeCatch)
        {
            if (list == null) { executeCatch(); }
            IEnumerator<T> enumerator = list.GetEnumerator();
            int count = list.Count();
            for (int i = 0; i < count; i++)
            {
                try
                {
                    enumerator.MoveNext();
                }
                catch
                {
                    executeCatch();
                }
                T item = enumerator.Current;
                yield return item;
            }    
        }
