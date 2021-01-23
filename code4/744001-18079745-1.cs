    public MainWindow()
    {
        InitializeComponent();
        TestConnection.DataRecieved += TestConnection_DataRecieved;
    }
    private void TestConnection_DataRecieved(string data)
    {
       // show data in listbox
    }
