    public MainWindowViewModel : INotifyPropertyChanged
    {
        public bool ProgressBarVisible {
            get { return progressBarVisible; }
            set { 
                progressBarVisible=value;
                RaisePropertyChanged("ProgressBarVisible");
            }
        }
        public void LoadImages() 
        {
            ProgressBarVisible = true;
            
            //your logic for downloading the images
            ProgressBarVisible = false;
        }
            
        public void DownloadImagesAsync()
        {
            Task.Factory.StartNew(LoadImages);
        }
    }
