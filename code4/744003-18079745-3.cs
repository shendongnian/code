    public MainWindow()
    {
        InitializeComponent();
        TestConnection.DataRecieved += TestConnection_DataRecieved;
    }
    private void TestConnection_DataRecieved(string data)
    { 
       if (InvokeRequired) // check if you are on main thread
       {
           // invoke same method on main thread
           Invoke((MethodInvoker)(() => TestConnection_DataRecieved(data)));
           return;
       }
       // show data in listbox
    }
