    namespace WpfApplication2
    {
        using System.ComponentModel;
    
        public class ViewModel : INotifyPropertyChanged
        {
            private int _fontSizeSetting = 10;
            public event PropertyChangedEventHandler PropertyChanged;
    
            public int FontSizeSetting
            {
                get { return _fontSizeSetting; }
                set
                {
                    _fontSizeSetting = value;
                    OnPropertyChanged("FontSizeSetting");
                }
            }
    
            protected virtual void OnPropertyChanged(string propertyName)
            {
                var handler = PropertyChanged;
                if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
