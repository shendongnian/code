    public class Customer : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string _firstName;
    
        public int Id { get; set; }
    
        public string FirstName 
        { 
            get { return _firstName; } 
            set 
            { 
                _firstName = value; // well, it's better to check if value changed
                if (PropertyChanged !=null) 
                    PropertyChanged(this, new PropertyChangedEventArgs("FirstName"));
            }
        }        
    }
