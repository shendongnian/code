    var orderBook = JsonConvert.DeserializeObject<Orderbook>(json); //Json.Net
    //OR
    var orderBook = new JavaScriptSerializer().Deserialize<Orderbook>(json);  //JavaScriptSerializer
    public class Orderbook
    {
        public List<List<string>> asks { get; set; }
        public List<List<string>> bids { get; set; }
    }
