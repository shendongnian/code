    using (WebClient wc = new WebClient())
    {
        var json = wc.DownloadString("http://coderwall.com/mdeiters.json");
        var jsonMarket = JsonConvert.DeserializeObject<Market>(json);
    }
    public class Market
    {
        [JsonProperty("high")]
        public string High{ get; set; }
        [JsonProperty("latest_trade")]
        public string LatestTrade { get; set; }
       
        [JsonProperty("bid")]
        public string Bid{ get; set; }
        [JsonProperty("volume")]
        public string Volume{ get; set; }
        [JsonProperty("currency")]
        public string Currency{ get; set; }
        [JsonProperty("currency_volume")]
        public string CurrencyVolume{ get; set; }
        [JsonProperty("ask")]
        public string Ask { get; set; }
        [JsonProperty("close")]
        public string Close { get; set; }
        [JsonProperty("avg")]
        public string AVG { get; set; }
        [JsonProperty("symbol")]
        public string Symbol { get; set; }
        [JsonProperty("low")]
        public string Low { get; set; }
    }
