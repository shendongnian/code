    public class ManagementObjectDisposer : IDisposable
    {
        private List<IDisposable> disposables = new List<IDisposable>();
    
        /// <summary>
        /// Workaround to dispose ManagementBaseObject properly.
        /// See http://stackoverflow.com/questions/11896282
        /// </summary>
        /// <param name="disposable"></param>
        public static void DisposeOne(IDisposable disposable)
        {
            ManagementBaseObject mbo = disposable as ManagementBaseObject;
            if (mbo != null)
                mbo.Dispose();
            else
                disposable.Dispose();
        }
    
        public void Dispose()
        {
            Exception firstException = null;
            foreach (IDisposable d in Enumerable.Reverse(disposables))
            {
                try
                {
                    DisposeOne(d);
                }
                catch (Exception ex)
                {
                    if (firstException == null)
                        firstException = ex;
                    else
                        cvtLogger.GetLogger(this).Error($"Swallowing exception when disposing: {d.GetType()}", ex);
                }
            }
            disposables.Clear();
            if (firstException != null)
                throw firstException;
        }
    
        public T Add<T>(T disposable) where T : IDisposable
        {
            disposables.Add(disposable);
            return disposable;
        }
    
        /// <summary>
        /// Helper for ManagementObjectSearcher with adding all objects to the disposables.
        /// </summary>
        /// <param name="query">The query string.</param>
        public IEnumerable<ManagementBaseObject> Search(string query)
        {
            ManagementObjectSearcher searcher = this.Add(new ManagementObjectSearcher(query));
            return EnumerateCollection(searcher.Get());
        }
    
        /// <summary>
        /// Helper for adding ManagementObjectCollection and enumerating it.
        /// </summary>
        public IEnumerable<ManagementBaseObject> EnumerateCollection(ManagementObjectCollection collection)
        {
            this.Add(collection);
            ManagementObjectCollection.ManagementObjectEnumerator enumerator = this.Add(collection.GetEnumerator());
            while (enumerator.MoveNext())
                yield return this.Add(enumerator.Current);
        }
    }
