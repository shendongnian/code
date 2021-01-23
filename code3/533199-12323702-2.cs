    public class ViewModel : INotifyPropertyChanged
    {
        private string _pageHeader = "This is my page header";
        public string PageHeader
        {
            get
            {
                return _pageHeader;
            }
            set
            {
                _pageHeader = value;
                PropertyChanged(this, new PropertyChangedEventArgs("PageHeader"));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
