    public class GoogleCurrencyService
    {
        private const string RequestUri = "http://www.google.com/ig/calculator?hl=en&q=1{0}%3D%3F{1}";
        public decimal ExchangeRate { get; private set; }
        public decimal GetRateForCurrency(string fromCurrency, string toCurrency)
        {
            ExchangeRate = 0;
            // use a signaler to block this thread and wait for the async call.
            var signaler = new ManualResetEvent(false);
            try
            {
                var client = new WebClient();
                client.DownloadStringCompleted += StringDownloadCompleted;
                // pass the signaler as user token
                client.DownloadStringAsync(new Uri(String.Format(RequestUri, fromCurrency, toCurrency)), signaler);
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
            try
            {
                ExchangeRate = ParseResponseAndGetExchangeRate(e.Result);
            }
            finally
            {
                // set signal
                ((ManualResetEvent)e.UserState).Set();
            }
        }
        private decimal ParseResponseAndGetExchangeRate(string result)
        {
            return 123;
        }
    }
