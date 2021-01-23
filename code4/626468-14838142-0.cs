    class TriggerWatcherDll
    {
        public static event EventHandler TriggerChanged;
        private static bool _trigger = false;
        public static bool IsTriggerOn
        {
            get { return _trigger; }
            set
            {
                if (_trigger != value)
                {
                    _trigger = value;
                    if (TriggerChanged != null)
                        TriggerChanged.Invoke(null, new EventArgs());
                }
            }
        }
    }
