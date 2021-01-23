    class AccountEvent
    {
        public Account acct { get; private set; }
        public TimeSpan dueTime { get; set; }
        public ActionType action { get; private set; } // follow, re-tweet, etc.
        // constructor, etc.
    }
