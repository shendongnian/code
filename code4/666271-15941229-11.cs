    [Route("/bookinglimits/{Id}")]
    public class GetBookingLimit : IReturn<BookingLimit>
    {
        public int Id { get; set; }
    }
    
    public class BookingLimit
    {
        public int Id { get; set; }
        public int ShiftId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Limit { get; set; }
    }
    
    [Route("/bookinglimits/search")]
    public class FindBookingLimits : IReturn<List<BookingLimit>>
    {      
        public DateTime BookedAfter { get; set; }
    }
