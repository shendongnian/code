    private bool _showProgressBar = false;
    public bool ShowProgressBar
    {
        get { _return _showProgressBar; }
        set 
        { 
            _return _showProgressBar;
            OnPropertyChanged("ShowProgressBar");
        }
    }
    public void LoadData()
    {
        try
        {
            string defaulturl = "http://....";
            WebClient client = new WebClient();
            Uri uri = new Uri(defaulturl);
            client.DownloadStringCompleted += new DownloadStringCompletedEventHandler(client_DownloadStringCompleted);
            ShowProgressBar = true;
            client.DownloadStringAsync(uri);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
        this.IsDataLoaded = true;
    }
    void client_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
    {
        try
        {
            //fetch the data
            ShowProgressBar = false;
        }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
