    public class Personel : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
    
            private string _name;
            public string Name
            {
                get { return _name; }
                set { _name = value; OnChanged("Name");}
            }
    
           
            void OnChanged(string pn)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(pn));
                }
            }
        }
