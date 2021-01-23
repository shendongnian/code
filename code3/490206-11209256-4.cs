     public partial class Window1 :INotifyPropertyChanged
        {
            public Window1()
            {
    
                DataContext = this;
               // var rect = new Rectangle();
                using (FileStream stream = new FileStream("MyStyle.xaml", FileMode.Open))
                {
                    var RD =  XamlReader.Load(stream) as ResourceDictionary;
    
                    Style style = (Style)RD["MyStyle"];
                    bStyle = style;
                }
    
                
            }
    
            private Style _BStyle;
            public Style bStyle
            {
                get
                {
                    return _BStyle;
                }
                set
                {
                    _BStyle = value;
                    OnPropertyChanged("bStyle");
                }
            }
            
    
            public event PropertyChangedEventHandler PropertyChanged;
            // Create the OnPropertyChanged method to raise the event
            protected void OnPropertyChanged(string name)
            {
                PropertyChangedEventHandler handler = PropertyChanged;
                if (handler != null)
                {
                    handler(this, new PropertyChangedEventArgs(name));
                }
            }
        }
