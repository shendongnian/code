    public class CurrencyRateResponse
    {
        public string disclaimer { get; set; }
        public string license { get; set; }
        public string timestamp { get; set; }
        public string @base { get; set; }
        public Dictionary<string,decimal> rates { get; set; }
    }
    JavaScriptSerializer ser = new JavaScriptSerializer();
    var obj =  ser.Deserialize<CurrencyRateResponse>(json);
    var rate = obj.rates["AMD"];
