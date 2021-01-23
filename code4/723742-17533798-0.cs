        private object engineLock = new object();
        public virtual ILessEngine GetEngine()
        {
            lock( engineLock ) { return lessEngine ?? (lessEngine = CreateEngine()); }
        }
