    class Booking
    {
        public int ID { get; set;}
        public int BookingNumber { get; set;}
        public string ReferenceNo { get; set;}
        public string Name { get; set;}
        public string Address { get; set;}
    }
    class BookingDetails
    {
        public int ID { get; set;}
        public int BookingId { get; set;}
        public string OrderItem { get; set;}
    }
