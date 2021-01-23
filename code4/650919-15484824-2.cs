    public class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        private Test1ViewModel _contentModel;
        public Test1ViewModel ContentModel { get { return _contentModel; } set { _contentModel = value; OnPropertyChanged("ContentModel"); } }
        public ViewModel()
        {
            this.ContentModel = new Test1ViewModel() { Name = "John Higgins", Address = "Wishaw" };
        }
    }
    public class Test1ViewModel : INotifyPropertyChanged
    {
        private string _name;
        public string Name { get { return _name; } set { _name = value; OnPropertyChanged("Name"); } }
        private string _address;
        public string Address { get { return _address; } set { _address = value; OnPropertyChanged("Address"); } }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
