    static public void isBarcodeCorrectOnServer(string barcode, Action<string> completed)
    {
        //..
        wc.DownloadStringCompleted += (sender, e) =>
        {
           if (e.Error == null)
           {
                //Process the result...
                data = e.Result;
                completed(data);
           }
        };
        //..
    }
