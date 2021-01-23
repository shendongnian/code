     public class Item : INotifyPropertyChanged
        {
            public Item()
            {
            }
            public event PropertyChangedEventHandler PropertyChanged;
            private string _name;
            public string name { set { _name = value; OnPropertyChanged("name"); } get { return _name; } }
            private string _color;
            public string color { set { _color = value; OnPropertyChanged("color"); } get { return _color; } }
            protected void OnPropertyChanged(string name)
            {
                PropertyChangedEventHandler handler = PropertyChanged;
                if (handler != null)
                {
                    handler(this, new PropertyChangedEventArgs(name));
                }
            }
    
        }
