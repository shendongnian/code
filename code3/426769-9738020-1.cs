    [Serializable]
    public class LazyLoadAttribute : LocationInterceptionAspect, IInstanceScopedAspect
    {
        // Concurrent accesses management
        private readonly object _locker = new object();
        // the backing field where the loaded value is stored the first time.
        private object _backingField;
        // More reliable than checking _backingField for null as the result of the loading could be null.
        private bool _hasBeenLoaded = false;
        public override void OnGetValue(LocationInterceptionArgs args)
        {
            if (_hasBeenLoaded)
            {
                // Job already done
                args.Value = _backingField;
                return;
            }
            lock (_locker)
            {
                // Once the lock passed, we must check if the aspect has been loaded meanwhile or not.
                if (_hasBeenLoaded)
                {
                    args.Value = _backingField;
                    return;
                }
                // First call to the getter => need to load it.
                args.ProceedGetValue();
                // Indicate that we Loaded it
                _hasBeenLoaded = true;
                // store the result.
                _backingField = args.Value;
            }
        }
        public object CreateInstance(AdviceArgs adviceArgs)
        {
            return MemberwiseClone();
        }
        public void RuntimeInitializeInstance() { }
    }
