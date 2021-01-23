    public class Progress : INotifyPropertyChanged
        {
            int _values;
            public int Values
            {
                get
                {
                    return _values;
                }
                set
                {
                    if (value != _values)
                    {
                        _values = value;
                        NotifyPropertyChanged("Values");
                    }
                }
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
            private void NotifyPropertyChanged(String propertyName)
            {
                PropertyChangedEventHandler handler = PropertyChanged;
                if (null != handler)
                {
                    handler(this, new PropertyChangedEventArgs(propertyName));
                }
            }
        }
     public class MainViewModel : INotifyPropertyChanged
        {
            List<Progress> _progress = new List<Progress>();
            int _values = 100;
            public MainViewModel()
            {
                this.Items = new ObservableCollection<ItemViewModel>();
                _progress.Add(new Progress());
                _progress.Add(new Progress());
                _progress[0].Values = 50;
                _progress[1].Values = 100;
    
            }
         ...
         }
