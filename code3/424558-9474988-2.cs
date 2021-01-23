    class Top
    {
        public Request Request { get; set; }
        public Response Response { get; set; }
    }
    class Request
    {
        public string Format { get;set; }
        // etc.
    }
 
    class Response
    {
        public int Status { get; set; }
        public Dictionary<int, AffiliateHolder> Data { get; set; }
    }
    class AffiliateHolder
    {
        public Affiliate Affiliate { get; set; }
    }
    class Affiliate
    {
        public int Id { get; set; }
        // etc.
    }
    var o = JsonConvert.DeserializeObject<Top>(myJSONString);
