    public decimal GetRateForCurrency(string fromCurrency, string toCurrency)
    {
        ExchangeRate = 0;
        // use a signaler to block this thread and wait for the async call.
        var signaler = new ManualResetEvent(false);
        try
        {
            WebClient client = new WebClient();
            client.DownloadStringCompleted += StringDownloadCompleted;
            // pass the signaler as user token
            client.DownloadStringAsync(
                new Uri(_requestUri + fromCurrency + "=?" + toCurrency), 
                signaler);
            // wait for signal, it will be set by StringDownloadCompleted
            signaler.WaitOne();
        }
        finally
        {
            signaler.Dispose();
        }
    
        return ExchangeRate;
    }
    
    private void StringDownloadCompleted(object sender, DownloadStringCompletedEventArgs e)
    {
        _response = e.Result;
        ExchangeRate = ParseResponseAndGetExchangeRate();
        // set signal
        ((ManualResetEvent) e.UserState).Set();
    }
