    public class AViewModel
    {
        public string Id1 { get; set; }
        public string Id2 { get; set; }
        public string Id3 { get; set; }
        public RouteValueDictionary routeValues
        {
            get
            {
                return new RouteValueDictionary(
                    new { Id1 = Id1, Id2 = Id2, Id3 = Id3 });
            }
            private set;
        }
    }
