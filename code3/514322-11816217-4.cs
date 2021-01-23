    public class GoogleCurrencyService
    {
        private const string RequestUri = "http://www.google.com/ig/calculator?hl=en&q=1{0}%3D%3F{1}";
        public void GetRateForCurrency(string fromCurrency, string toCurrency, Action<decimal> callback)
        {
            var client = new WebClient();
            client.DownloadStringCompleted += StringDownloadCompleted;
            // pass the callback as user token
            client.DownloadStringAsync(new Uri(String.Format(RequestUri, fromCurrency, toCurrency)), callback);
        }
        private void StringDownloadCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            // parse response to get the rate value
            var rate = ParseResponseAndGetExchangeRate(e.Result);
            // if a callback was specified, call it passing the rate.
            var callback = (Action<decimal>)e.UserState;
            if (callback != null)
                callback(rate);
        }
        private decimal ParseResponseAndGetExchangeRate(string result)
        {
            return 123;
        }
    }
