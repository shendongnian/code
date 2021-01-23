    public async MainPage()
    {
        InitializeComponent();
        DoAsyncLoad();
    }
    private async Task DoAsyncLoad()  // note use of "async" keyword
    {
       if (NetworkInterface.GetIsNetworkAvailable())
       {
            await LoadSiteContent_A("");
            await LoadSiteContent_B("");
       }
       else
            MessageBox.Show("No Internet Connection, please connect to use this applacation");
       listBox.ItemsSource = top; //trying to bind listbox after web calls
    }
    public async Task LoadSiteContent_A(string url)
    {
         //create a new WebClient object
         WebClient clientC = new WebClient();
         var result = await clientC.DownloadStringTaskAsync(new Uri(url));
         // No need for a Lambda or setting up an event
         var testString = result; // result is the string you were waiting for (will be empty of canceled or errored) 
    }
    public async Task LoadSiteContent_B(string url)
    {
         //create a new WebClient object
         WebClient clientC = new WebClient();
         var result = await clientC.DownloadStringTaskAsync(new Uri(url));
         // Again, no need for a Lambda or setting up an event (code is simpler as a result)
         top.Add(new Top(testMatch, place.Count + 1));
     }
