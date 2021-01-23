    public class Range : INotifyPropertyChanged
    {
        // Declare the event
        public event PropertyChangedEventHandler PropertyChanged;
    
        public string range_name { get; set {
            // Call OnPropertyChanged whenever the property is updated
            OnPropertyChanged("range_name");
        } }
        public string range_description { get; set {
            // Call OnPropertyChanged whenever the property is updated
            OnPropertyChanged("range_description");
        } }
        public int min { get; set {
            // Call OnPropertyChanged whenever the property is updated
            OnPropertyChanged("min");
        }  }
        public int max { get; set {
            // Call OnPropertyChanged whenever the property is updated
            OnPropertyChanged("max");
        }  }
    
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
