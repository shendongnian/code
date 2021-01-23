        private bool _recursive;
        public bool Recursive {
            get
            {
                return _recursive;
            }
            set
            {
                StackTrace stackTrace = new StackTrace();
                if (stackTrace.GetFrame(1).GetMethod().Name == "ItemIsWhitelisted")
                {
                    throw new Exception("Please don't");
                }
                _recursive = value;
            }
        }
