    public class CheckedListItem : INotifyPropertyChanged
    {
        private int _Id;
        public int Id 
        {
            get;
            set; NotifyIfAnythingChanged("Id");
        }
        private string _Name;
        public string Name
        {
            get;
            set; NotifyIfAnythingChanged("Name");
        }
        private bool _IsChecked;
        public bool IsChecked
        {
            get;
            set; NotifyIfAnythingChanged("IsChecked");
        }
        private void NotifyIfAnythingChanged(String propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
