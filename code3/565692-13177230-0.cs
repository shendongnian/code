    public partial class Window1 : Window,  INotifyPropertyChanged
    {
        BackgroundWorker bcLoad = new BackgroundWorker();
        private string _data;
        public string Data 
        { 
           get { return _data;} 
           set { _data = value; OnPropertyChanged("Data"); }
        }
     
        public Window1()
        {
            InitializeComponent();
     
            bcLoad.DoWork             += _backgroundWorker_DoWork;
            bcLoad.RunWorkerCompleted += _backgroundWorker_RunWorkerCompleted;
            bcLoad.RunWorkerAsync();
        }
        protected virtual void OnPropertyChanged( string propertyName )
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler( this, new PropertyChangedEventArgs( propertyName ) );
            }
        }
     }
