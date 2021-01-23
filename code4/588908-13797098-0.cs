            public MainWindow()
            {
                InitializeComponent(); 
    
                this.Closing += new System.ComponentModel.CancelEventHandler(MainWindow_Closing);
            }
    
            void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
            {
                //ask the user to save , if needed to 
            } 
