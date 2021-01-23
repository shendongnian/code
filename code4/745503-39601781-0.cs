            public ICommand ButtonCommand { get; set; }
    
            public MainWindowViewModel()
            {
                ButtonCommand = new RelayCommand(o => MainButtonClick("MainButton"));
            }
    
            private void MainButtonClick(object sender)
            {
                MessageBox.Show(sender.ToString());            
            }
