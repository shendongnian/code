    //use the convention of eventName+EventArgs
    class MemberChangedEventArgs : EventArgs
    {
        public readonly float LastValue{
            get;
            set;
        }
        public readonly float NewValue{
            get;
            set;
        }
        public MemberChangedEventArgs(float LastValue, float NewValue)
        {
            this.LastValue = LastValue;
            this.NewValue = NewValue;
        }
    }
