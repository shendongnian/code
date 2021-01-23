        public System.Threading.SynchronizationContext Context
        {
            get;
            set;
        }
        public MyWorker(SynchronizationContext context)
        {
            this.Context = context;
        }
