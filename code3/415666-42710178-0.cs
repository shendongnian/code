        Below code will work fine, CurrencyRates is collection so that by using List we can take all reates.
        This should work!!
        
        public class CurrencyRateResponse
        {
            public string disclaimer  { get; set; }
            public string license { get; set; }
            public string timestamp { get; set; }
            public string basePrice { get; set; }        
            public List<CurrencyRates> rates { get; set; }
        }
        
        public class CurrencyRates
        {
            public string AED  { get; set; }    
            public string AFN  { get; set; }    
            public string ALL  { get; set; }    
            public string AMD  { get; set; }  
        }
    
    JavaScriptSerializer ser = new JavaScriptSerializer();
    var obj =  ser.Deserialize<CurrencyRateResponse>(json);
    var rate = obj.rates["AMD"]; 
