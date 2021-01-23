    WebClient client = new WebClient();
    string url = lines[i];
    try //place the try block only where an exception may occur, it slows down the performance
    {
        string downloadString = client.DownloadString(url);
        client.Dispose(); //dispose the object because you don't need it anynmore
    }
    catch (Exception exce)
    {
        MessageBox.Show("Error downlaoding page: \n\n" + exce.Message);
    }
    finally //the portion will always execute and has no chance of exception
    {
        findNewListings(downloadString, url);
    }
