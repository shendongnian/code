    public class City
    {
        public string Name { get; set; }
        public List<Restaurant> RestaurantList { get; set; }
    }
    
    public class Restaurant
    {
        public string Name { get; set; }
        public List<Uri> UriList { get; set; }
    }
