    public class MyClass : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
        private string myProperty;
        public string MyProperty
        {
            get
            {
                return this.myProperty;
            }
            set
            {
                if (value != this.myProperty)
                {
                    this.myProperty = value;
                    NotifyPropertyChanged("MyProperty");
                }
            }
        }
    }
