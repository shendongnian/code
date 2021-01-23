     public class SudokuViewModel:INotifyPropertyChanged
        {
            public int Row { get; set; }
    
            public int Column { get; set; }
    
            private int _value;
            public int Value
            {
                get { return _value; }
                set
                {
                    _value = value;
                    NotifyPropertyChange("Value");
                }
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            public void NotifyPropertyChange(string propertyName)
            {
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));        
            }
    
        }
