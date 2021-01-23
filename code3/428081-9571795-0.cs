    string result = "";
    bool success = false;
    int remainingAttempts = 5;
    while(success == false && remainingAttempts > 0) {
        remainingAttempts--;
        try
        {
            WebClient client = new WebClient();
            result = client.DownloadString(url);
            success = true;
        }
        catch (WebException ex)
        {
        }
        if(success == false) {
            System.Threading.Thread.Sleep(1000);
        }
    }
