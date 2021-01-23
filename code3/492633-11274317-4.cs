        private readonly System.Threading.SynchronizationContext context;
        public System.Threading.SynchronizationContext Context
        {
            get{ return this.context;}
        }
        public MyWorker(SynchronizationContext context)
        {
            this.context = context;
        }
