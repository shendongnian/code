    public MainPage()
            {
                InitializeComponent();
                Thread thread = new Thread(() => ReadFile(/*params*/));
                thread.Start();
            }
    
            private void ReadFile(/*params*/)
            {   
                while(/*condition*/)
                {
                    /* READ FILE */
    
                    //send task to UI thread to add object to list box
                    Dispatcher.BeginInvoke(() => listBox1.Items.Add("YOUR OBJECT"));
                }
            }
