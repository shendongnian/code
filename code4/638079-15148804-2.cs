    public class Person : INotifyPropertyChanged
    {
        private string _name;
        private bool _isEditing;
        public string Name
        {
            get { return _name; }
            set { _name = value; NotifyPropertyChanged("Name"); }
        }
        public bool IsEditing
        {
            get { return _isEditing; }
            set { _isEditing = value; NotifyPropertyChanged("IsEditing"); }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
