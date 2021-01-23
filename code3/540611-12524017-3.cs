        public IEnumerable<T> TryForEach<T>(IEnumerable<T> list, Action executeCatch)
        {
            if (list == null) { executeCatch(); }
            IEnumerator<T> enumerator = list.GetEnumerator();
            bool success = false;
            do
            {
                try
                {
                    success = enumerator.MoveNext();
                }
                catch
                {
                    executeCatch();
                    success = false;
                }
                if (success)
                {
                    T item = enumerator.Current;
                    yield return item;
                }
            } while (success);
        }
