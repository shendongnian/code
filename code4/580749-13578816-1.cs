    public SomeObjectThatNeedsToNotifySomething : NotificationObject
    {
        public int SomeValue
        {
            get { return Get<int>("SomeValue"); }
            set { Set<int>(value, "SomeValue", "SomeAggregateValue"); }
        }
        public int SomeOtherValue
        {
            get { return Get<int>("SomeOtherValue"); }
            set { Set<int>(value, "SomeOtherValue", "SomeAggregateValue"); }
        }
        public int SomeAggregateValue
        {
            get { return SomeValue + SomeOtherValue; }
        }
    }
