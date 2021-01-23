    [Route("/bookinglimit", "GET")]
    [Authenticate]
    public class GetBookingLimit : IReturn<BookingLimitDto>
    {
        public int Id { get; set; }
    }
    [Route("/bookinglimits", "GET")]
    [Authenticate]
    public class GetBookingLimits : IReturn<List<BookingLimitDto>>
    {
        public DateTime Date { get; set; }
    }
