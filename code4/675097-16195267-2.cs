            public MainViewModel()
            {
                this.CloseWindowCommand = new RelayCommand<Window>(this.CloseWindow);
            }
    
     private void CloseWindow(Window window)
            {
                if (window != null)
                {
                    window.Close();
                }
            }
