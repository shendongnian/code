    public async MainPage()
    {
        InitializeComponent();
        DoAsyncLoad();
    }
    private async Task DoAsyncLoad()  // note use of "async" keyword
    {
        if (NetworkInterface.GetIsNetworkAvailable())
        {
            await LoadSiteContent_A(url1);  // note use of "await"
            //next line will continue after last routine finishes
            await LoadSiteContent_B(url2);
        }
        else
            MessageBox.Show("No Internet Connection, please connect to use this applacation");
        listBox.ItemsSource = top; //trying to bind listbox after web calls
    }
