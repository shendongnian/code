    class Security : INotifyPropertyChanged
    {   
        public event PropertyChangedEventHandler PropertyChanged;
    
        public string Ticker 
        { 
            get { return ticker; } 
            set { 
                   ticker = value; 
                   PropertyChanged(this, new PropertyChangedEventArgs("Ticker"));
            }
        }
        ...// implement the rest of your class like above
     }
