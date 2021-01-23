    public class UserPanel
    {
        public string Title { get; set; }
        public string ToolTip { get; set; }
        public string IconSource { get; set; }
      
        private Guid _contentGuid = Guid.NewGuid();
        public Guid ContentId
        {
            get { return _contentGuid; }
            set { _contentGuid = value; }
        }
        private UserControl _UserInterface;
        public UserControl UserInterface { get { return _UserInterface; } set { _UserInterface = value; NotifyPropertyChanged("UserInterface"); } }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                Debug.WriteLine(string.Format("PropertyChanged-> {0}", propertyName));
            }
        }
    }
