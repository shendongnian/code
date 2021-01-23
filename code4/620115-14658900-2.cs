    public class Class1 : NotifyBase
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; NotifyPropertyChanged("Name"); }
        }
    }
    public class ABC : NotifyBase
    {
        private string name;
        public string Name1
        {
            get { return name; }
            set { name = value; NotifyPropertyChanged("Name1"); }
        }
    }
    public class NotifyBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
