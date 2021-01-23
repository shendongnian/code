    public partial class MyTabItem : TabItem, INotifyPropertyChanged
    {
        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
        #endregion
        #region Properties
        private string myTitle;
        public string MyTitle
        {
            get { return myTitle; } 
            set 
            {
                myTitle = value;
                OnPropertyChanged("MyTitle");
            }
        }
        private string myContent;
        public string MyContent { 
            get { return myContent; } 
            set 
            { 
                myContent = value;
                OnPropertyChanged("MyContent");
            } 
        }
        #endregion
        public MyTabItem()
        {
            InitializeComponent();
        }
    }
