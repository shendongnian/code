    public MainWindow()
    {
       InitializeComponent();
    
       PrintServer server = new PrintServer();
    
       foreach (PrintQueue queue in server.GetPrintQueues())
       {
          cboPrinters.Items.Add(queue);
       }
    }
