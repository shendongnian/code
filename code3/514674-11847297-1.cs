    public class Person : INotifyPropertyChanged
    {
        private string name;
        public event PropertyChangedEventHandler PropertyChanged;
        public string Name
        {
            get { return name; }
            set
            {
                object before = Name;
                name = value;
                OnPropertyChanged("Name", before, Name);
            }
        }
        public void OnPropertyChanged(string propertyName, object before, object after)
        {            
            // do something with before/after
            var propertyChanged = PropertyChanged;
            if (propertyChanged != null)
            {
                propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
