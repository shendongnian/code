        static private IList<Booking> _bookings = new List<Booking>() {
            new Booking() { ID = 32, BookingNumber = 12120001, ReferenceNo = "ABCED11212280007", Name = "Customer Name1", Address = "Customer Address" },
            new Booking() { ID = 33, BookingNumber = 12120002, ReferenceNo = "ABCED11212280008", Name = "Customer Name2", Address = "Customer Address2" }
        };
        static private IList<BookingDetails> _details = new List<BookingDetails>() {
            new BookingDetails() { ID = 206, BookingId = 32, OrderItem = "Item1" },
            new BookingDetails() { ID = 207, BookingId = 32, OrderItem = "Item2" },
            new BookingDetails() { ID = 208, BookingId = 33, OrderItem = "Item1" },
            new BookingDetails() { ID = 209, BookingId = 33, OrderItem = "Item2" },
            new BookingDetails() { ID = 210, BookingId = 33, OrderItem = "Item3" }
        };
