    public class Customer : INotifyPropertyChanged
    {
        public string FirstName
        {
            get { return firstName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    // oops!
                }
    
                if (firstName != value)
                {
                    firstName = value;
                    OnPropertyChanged("FirstName"); // raises INotifyPropertyChanged.PropertyChanged
                }
            }
        }
        private string firstName;
    
        public string LastName { /* ... */}
    }
