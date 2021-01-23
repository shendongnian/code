    BackgroundWorker createAndSaveAMatchBGW;
            public Form1()
            {
                InitializeComponent();
                createAndSaveAMatchBGW = new BackgroundWorker();
                createAndSaveAMatchBGW.DoWork += new DoWorkEventHandler(createAndSaveAMatchBGW_DoWork);
                createAndSaveAMatchBGW.RunWorkerCompleted += new RunWorkerCompletedEventHandler(createAndSaveAMatchBGW_RunWorkerCompleted);
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                createAndSaveAMatchBGW.RunWorkerAsync(DateTime.Now);
            }
    
            void createAndSaveAMatchBGW_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
            {
                label1.Text = ((DateTime)e.Result).ToString();
            }
    
            void createAndSaveAMatchBGW_DoWork(object sender, DoWorkEventArgs e)
            {
                DateTime dt = (DateTime) e.Argument;
                //you do something with your DateTime
                dt = dt.AddDays(10);
                e.Result = dt;
            }
