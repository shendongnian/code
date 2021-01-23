    var bookings = _bookings.Join(_details, b => b.ID, d => d.BookingId, (b, d) => new { b, d })
                            .GroupBy(g => g.b, g => g.d)
                            .Select(g => new XElement("Booking", 
                                            new XElement("ID", g.Key.ID),
                                            new XElement("BookingNumber", g.Key.BookingNumber),
                                            new XElement("ReferenceNo", g.Key.ReferenceNo),
                                            new XElement("Name", g.Key.Name),
                                            new XElement("Address", g.Key.Address),
                                            new XElement("Details",
                                                g.Select(d => new XElement("Detail",
                                                                  new XElement("ID", d.ID),
                                                                  new XElement("OrderItem", d.OrderItem))).ToArray()))).ToArray();
    
    var data = new XDocument(new XElement("Bookings", bookings));
