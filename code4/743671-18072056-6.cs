     public class MyColors : INotifyPropertyChanged
        {
            private SolidColorBrush _color1;
    
            // Declare the PropertyChanged event.
            public event PropertyChangedEventHandler PropertyChanged;
    
            // Create the property that will be the source of the binding.
            public SolidColorBrush color1
            {
                get { return _color1; }
                set
                {
                    _color1 =value;
                    NotifyPropertyChanged("color1");
                }
            }
    
            public void NotifyPropertyChanged(string propertyName)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this,
                        new PropertyChangedEventArgs(propertyName));
                }
            }
        }
