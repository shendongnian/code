        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (System.IO.File.Exists("library"))
            {
                _songData = getStoredData();
            }
        }
        private ObservableCollection<songInfo> songData = new ObservableCollection<songInfo>();
        public ObservableCollection<songInfo> _songData
        {
            get { return songData; }
            set { songData = value; }
        }
