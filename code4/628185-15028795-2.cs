    public static void Main(string[] args)
    {
      //Create new booking objects
      var booking1 = new XMLEntities.Booking()
                      {
                        ID = 32,
                        BookingNumber = 1212001,
                        ReferenceNumber = "ABCED11212280007",
                        Name = "Customer Name1",
                        Address = "Customer Address"
                      };
      var booking2 = new XMLEntities.Booking()
                       {
                         ID = 33,
                         BookingNumber = 12120002,
                         ReferenceNumber = "ABCED11212280008",
                         Name = "Customer Name2",
                         Address = "Customer Address2"
                       };
      
      //Create the booking details objects
      
      var booking1Detail1 = new XMLEntities.BookingDetail()
                             {
                               ID = 206,
                               BookingID = 32,
                               OrderItem = "Item1"
                             };
      var booking1Detail2 = new XMLEntities.BookingDetail()
                              {
                                ID = 207,
                                BookingID = 32,
                                OrderItem = "Item2"
                              };
      var booking2Detail1 = new XMLEntities.BookingDetail()
                              {
                                ID = 208,
                                BookingID = 33,
                                OrderItem = "Item1"
                              };
      var booking2Detail2 = new XMLEntities.BookingDetail()
                              {
                                ID = 209,
                                BookingID = 32,
                                OrderItem = "Item2"
                              };
      var booking2Detail3 = new XMLEntities.BookingDetail()
                              {
                                ID = 210,
                                BookingID = 32,
                                OrderItem = "Item3"
                              };
      
      //Smash them together so we can serialize as one
      
      var completeBooking1 = new XMLEntities.CompleteBooking()
                              {
                                Bookings = booking1,
                                BookingDetail = new List<XMLEntities.BookingDetail>()
                                                  {
                                                    booking1Detail1,
                                                    booking1Detail2
                                                  }
                              };
      var completeBooking2 = new XMLEntities.CompleteBooking()
                               {
                                 Bookings = booking2,
                                 BookingDetail = new List<XMLEntities.BookingDetail>()
                                                   {
                                                     booking2Detail1,
                                                     booking2Detail2,
                                                     booking2Detail3
                                                   }
                               };
      
      //Serialize the data for each of the booking objects
      var serializedXML = new XMLEntitiesSerializer();
      var xml = string.Empty;
      var booking1XmlString = serializedXML.Serialize(completeBooking1);
      var booking2XmlString = serializedXML.Serialize(completeBooking2);
      Console.ReadLine();
    }
