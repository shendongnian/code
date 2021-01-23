    class Response : Message
    {
        [ParameterOrder(0)]
        public int Code { get; set; }
    }
    class RegionsResponse : Response 
    {
        [ParameterOrder(1)]
        public string Regions { get; set; }
    }
    class HousesResponse : Response
    {
        public string Houses { get; set; }
    }
