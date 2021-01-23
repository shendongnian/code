    public static class Session
    {
        private static IStateManager _manager;
        private static IStateManager Manager
        {
            get
            {
                if (_manager == null)
                {
                    IStateManager m = null; // Get instance using IoC container
                    Interlocked.CompareExchange(ref _manager, m, null);
                }
                
                return _manager;
            }
        }
        public static string CurrentUser
        {
            get { return Manager.GetItem<string>("CurrentUser"); }
            set { Manager.SetItem<string>("CurrentUser", value); }
        }
        // The rest is similar
    }
