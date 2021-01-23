    public class AViewModel
    {
        public string Id1 { get; set; }
        public string Id2 { get; set; }
        public string Id3 { get; set; }
        public RouteValueDictionary GetRouteValues()
        {
            return new RouteValueDictionary( new { 
                Id1 = !String.IsNullOrEmpty(Id1) ? Id1 : String.Empty,
                Id2 = !String.IsNullOrEmpty(Id2) ? Id2 : String.Empty,
                Id3 = !String.IsNullOrEmpty(Id3) ? Id3 : String.Empty
            });
        }
    }
