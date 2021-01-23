    public class SafeInitializater
    {
        private bool _initialized;
        private object _dummy;
        private object _syncLock;
    
        public void InitializeOnce(Action initializer)
        {
            LazyInitializer.EnsureInitialized(ref _dummy, ref _initialized, ref _syncLock, 
                () => {
                    initializer();
                    return null;
                });
        }
    }
