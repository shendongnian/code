    public class MedicationList : INotifyPropertyChanged
    {
        private string _description; // storage for property value
        public event PropertyChangedEventHandler PropertyChanged;
    
        public string Description
        {
            get { return _description; }
            set
            {
                if (_description == value) // check if value changed
                    return; // do nothing if value same
    
                _description = value; // change value
                OnPropertyChanged("Description"); // pass changed property name
            }
        }
        // this method raises PropertyChanged event
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null) // if there is any subscribers 
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
