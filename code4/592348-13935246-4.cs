     public Form1()
        {
            this.Closing += new CancelEventHandler(this.Form1_Closing);
            InitializeComponent();
        }
        
        private void Form1_Closing(Object sender, CancelEventArgs e)
                {
                    if (systemShutdown) Program.SystemEvents_SessionEnded(this, new Microsoft.Win32.SessionEndedEventArgs(Microsoft.Win32.SessionEndReasons.SystemShutdown));
                    else
                    {
                        e.Cancel = true;
                        this.Hide();
                    }
                }
