    public class Location
    {
         public string streetName { get; set; }
         public string houseNumber { get; set; }
         public string zipCode { get; set; }
         public string city { get; set; }
         public string country { get; set; }
         public double lat { get; set; }
         public double lng { get; set; }
    }
    
    public class Booking
    {
         public string arrivalAt { get; set; }
         public Location pickup { get; set; }
         public Location dropoff { get; set; }
         public string vehicleType { get; set; }
         public string comments { get; set; }
    }
