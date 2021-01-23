    public class myObject : INotifyPropertyChanged
    {
        // The class has to be initialized from the UI thread
        public SynchronizationContext context = SynchronizationContext.Current;
        bool _myValue;
        public bool myValue
        {
            get
            {
                return _myValue;
            }
            set
            {
                _myValue = value;
                if (PropertyChanged != null)
                    context.Send(
                        new SendOrPostCallback(o => 
                            PropertyChanged(this, new PropertyChangedEventArgs("myValue"))),
                        null);
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
