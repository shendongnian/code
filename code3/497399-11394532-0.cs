    private Index[] indicies;
    public class Index
    {
        public WaitHandle Updated =
            new EventWaitHandle(false, EventResetMode.AutoReset);
        public double _value;
        public double Value
        {
            get {return _value;}
            set
            {
                if(_value != value)
                {
                    _value = value;
                    Updated.Set();
                }
            }
        }
    }
    TaskFactory.StartNew(() =>
    {
        while(true)
        {
            WaitHandle.Any(indicies.Select(i => i.Updated));
            CalculateAndNotify();
        }
    });
