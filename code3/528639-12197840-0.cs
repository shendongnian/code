    public class Region  : INotifyPropertyChanged
        { 
            public Region(string name) 
            { 
                Name = name; Type = new ObservableCollection<Types>(); 
            } 
            private string name;
                    public string Name
            {
                get { return name; }
                set 
                { 
                    name = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("Name"));
                }
            }
            
            public ObservableCollection<Types> Type { get; set; }
    
            #region INotifyPropertyChanged Members
    
            public event PropertyChangedEventHandler PropertyChanged = (s, e) => { };
    
            #endregion
        }
