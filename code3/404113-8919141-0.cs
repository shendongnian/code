    BackgroundWorker backGroundWorker1;
            public frmWindow(string path)
            {
                InitializeComponent();
                DataType d;
    
                backGroundWorker1 = new BackgroundWorker();
    
                backGroundWorker1.DoWork += (s, e) =>
                {
                    System.Diagnostics.Debug.Write("Work started at: " + DateTime.Now + Environment.NewLine);
                    string path = e.Argument as string;
                    DataType data = new DataType(path);
                    e.Result = data;
                };
    
                backGroundWorker1.RunWorkerCompleted += (s, e) =>
                {
                    d = e.Result as DataType;
                    System.Diagnostics.Debug.Write("Work completed at: " + DateTime.Now + Environment.NewLine);
                };
    
                backGroundWorker1.RunWorkerAsync();
    
            }
