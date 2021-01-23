    public class GoogleCurrencyService
    {
        public decimal GetRateForCurrency(string fromCurrency, string toCurrency)
        {
    
            try
            {
                WebClient client = new WebClient();
                var response = client.DownloadString(new Uri(_requestUri + fromCurrency + "=?" + toCurrency));
                ExchangeRate = ParseResponseAndGetExchangeRate(response);
            }
            catch (Exception)
            {
                ExchangeRate = 0;
            }
    
            return ExchangeRate;
        }
    
     }//class GoogleCurrencyService
