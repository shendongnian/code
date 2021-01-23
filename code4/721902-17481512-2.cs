    WebClient client = new WebClient();
    string url = lines[i];
    try
    {
        string downloadString = client.DownloadString(url);
        client.Dispose(); //dispose the object because you don't need it anynmore
        findNewListings(downloadString, url);
    }
    catch (Exception exce)
    {
        MessageBox.Show("Error downlaoding page: \n\n" + exce.Message);
    }
