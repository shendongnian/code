    public class Class1 : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private int myValue;
        public int MyValue
        {
            get { return myValue; }
            set 
            {
                if (myValue != value)
                {
                    myValue = value;
                    OnPropertyChanged("MyValue");
                }
            }
        }
        protected virtual void OnPropertyChanged(string property)
        {
            var notify = PropertyChanged;
            if (notify != null)
                notify(this, new PropertyChangedEventArgs(property));
        }
    }
