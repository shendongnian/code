    public class SearchViewModel
    {
        public int? page { get; set; }
        public int? size { get; set; }
        //Land Related search criteria        
        public IEnumerable<Location> LocationSelection{ get; set; }
    }
