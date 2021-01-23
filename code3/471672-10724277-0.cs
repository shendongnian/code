     public class LogColumn : INotifyPropertyChanged
        {
            private string _Name;
    
            public string Name
            {
                get { return _Name; }
                set { _Name = value; Onchanged("Name"); }
            }
            private ColumnType _Type;
    
    
            public ColumnType Type
            {
                get { return _Type; }
                set { _Type = value; Onchanged("Type"); }
            }
            private bool _OrderBy;
    
            public bool OrderBy
            {
                get { return _OrderBy; }
                set { _OrderBy = value; Onchanged("OrderBy"); }
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
            public void Onchanged(string name)
            {
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs(name));
    
            }
        }
