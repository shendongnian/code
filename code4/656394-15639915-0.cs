      public class BaseViewModel : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
            private int _number;
    
            public BaseViewModel()
            {
                PropertyChanged += (o, p) =>
                                       {
                                           //this is the place you would do what you wanted to do
                                           //when the property has changed.
                                       };
            }
    
            [NotifyPropertyChangedInvocator]
            protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChangedEventHandler handler = PropertyChanged;
                if (handler != null) 
                    handler(this, new PropertyChangedEventArgs(propertyName));
            }
    
            public int Number
            {
                get { return _number; }
                set
                {
                    _number = value;
                    OnPropertyChanged("Number");
                }
            }
        }
