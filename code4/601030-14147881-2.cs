        public virtual Assembly ExecutableAssembly
        {
            get { return GetType().Assembly; }
        }
        protected override IDictionary<System.Type, System.Type> GetViewModelViewLookup()
        {
            return GetViewModelViewLookup(ExecutableAssembly, typeof (IMvxAndroidView));
        }
