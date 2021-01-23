    public class MyModel : INotifyPropertyChanged
    {
        private string _name;
        private string _companyName;
        public string Name
        {
            get { return _name; }
            set { _name = value; NotifyPropertyChanged("Name"); }
        }
        public string CompanyName
        {
            get { return _companyName; }
            set { _companyName = value; NotifyPropertyChanged("CompanyName"); }
        }
        public string DisplayMember
        {
            get { return string.Format("{0} ({1})", Name, CompanyName); }
            
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
                PropertyChanged(this, new PropertyChangedEventArgs("DisplayMember"));
            }
        }
    }
