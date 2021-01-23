    public class PlacesAndEventsViewModel
    {
        public string LocationOption { get; set; }  //places or events
    
        public List<Place> Places { get; set; }
    
        public List<Event> Events { get; set; }
    
        public int? CityID { get; set; }
    }
