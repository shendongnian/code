    public class Response
    {
        public string loopa { get; set; }
        public string drupa{ get; set; }
        public Image[] images { get; set; }
    }
    public class RootObject<T>
        {
            public List<T> response{ get; set; }
        }
    
    var des = (RootObject<Response>)Newtonsoft.Json.JsonConvert.DeserializeObject(Your JSon String, typeof(RootObject<Response>));
   
