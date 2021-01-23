    var fbPages = fb.Get<IDictionary<string, FBPage>>(new { 
        ids = new[] { "...", "..." } 
    }).Values;
    
    public class FBPage
    {
        public string id { get; set; }
        public string name { get; set; }
    }
