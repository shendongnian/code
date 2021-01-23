    class Program
    {
        static void Main(string[] args)
        {
            HttpWebRequest wr = (HttpWebRequest)WebRequest.Create(@"https://raw.github.com/currencybot/open-exchange-rates/master/latest.json");
            wr.Timeout = 30 * 1000;
            HttpWebResponse response = (HttpWebResponse)wr.GetResponse();
            using (var s = new StreamReader(response.GetResponseStream()))
            {
                string json = s.ReadToEnd();
                var oerr = JsonConvert.DeserializeObject<OpenExchangeRatesResult>(json);
                Console.WriteLine(json);
            }
        }
    }
