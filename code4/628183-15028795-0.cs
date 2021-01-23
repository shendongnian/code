    public class XMLEntities
    {   
      [XmlRoot(ElementName = "CompleteBooking")]
      public class CompleteBooking
      {
        [XmlElement(ElementName = "Booking")]
        public Booking Bookings { get; set; }
        [XmlElement(ElementName = "BookingDetail")]
        public List<BookingDetail> BookingDetail { get; set; }
      }
      public class Booking
      {
        [XmlElement("ID")]
        public int ID { get; set; }
        [XmlElement("BookingNumber")]
        public int BookingNumber { get; set; }
        [XmlElement("ReferenceNumber")]
        public string ReferenceNumber { get; set; }
        [XmlElement("Name")]
        public string Name { get; set; }
        [XmlElement("Address")]
        public string Address { get; set; }
      }
      public class BookingDetail
      {
        [XmlElement("ID")]
        public int ID { get; set; }
        [XmlElement("BookingID")]
        public int BookingID { get; set; }
        [XmlElement("OrderItem")]
        public string OrderItem { get; set; }
      }
    }
