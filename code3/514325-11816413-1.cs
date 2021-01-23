     private void StringDownloadCompleted(object sender, DownloadStringCompletedEventArgs e)
    {
        _response = e.Result;
        yourlabel.Text = _response ;
        ExchangeRate = ParseResponseAndGetExchangeRate();
    }
