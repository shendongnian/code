       public class ClsReport
            {
             
                [JsonProperty(PropertyName="Realtime")]
                public bool? Realtime { get; set; }
               
               [JsonProperty(PropertyName="Report")]
                public List<string> ReportItems { get; set; }
            }
 
            [TestMethod]
            public void MyTestMethod()
            {
                string jsonString = @"
    {
        'Report': [
            '2012m01d01',
            '2012m01d02',
            '2012w01',
            '2012m01',
            '2012m01d03',
            '2012m01d04',
            '2012m01d05',
            '2012m01d06',
            '2012m01d07',
            '2012m01d08'
        ],
        'Realtime': null
    }";
    
                JsonSerializer json = new JsonSerializer();
                var settings = new JsonSerializerSettings
                {
    
                    MissingMemberHandling = MissingMemberHandling.Error,
                    NullValueHandling = NullValueHandling.Include
    
                };
                json.Error += (x, y) =>
                {
                    var s = y.ErrorContext;
                    var t = y.CurrentObject;
                    
                };
    
                var o = Newtonsoft.Json.JsonConvert.DeserializeObject<ClsReport>(jsonString, settings);
    
                string sf = o.ReportItems[2];
    
                   
        }
