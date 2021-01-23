    public class HotelAssignmentViewModel
    {
        public int Hotel_Id { get; set; } 
        public HotelPropertyViewModel[] HotelProperties { get; set; }
    }
    
    public class HotelPropertyViewModel
    {
        public int HotelProperty_Id { get; set; }
        public string Language { get; set; }
        public string Value  { get; set; }
    }
