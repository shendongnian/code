    var bookings = _bookings.Join(_details, b => b.ID, d => d.BookingId, (b, d) => new { b, d })
                            .GroupBy(g => g.b, g => g.d)
                            .Select(g => new XElement("CompleteBooking",
                                            new XElement("Booking", 
                                                new XElement("ID", g.Key.ID),
                                                new XElement("BookingNumber", g.Key.BookingNumber),
                                                new XElement("ReferenceNo", g.Key.ReferenceNo),
                                                new XElement("Name", g.Key.Name),
                                                new XElement("Address", g.Key.Address)),
                                            g.Select(d => new XElement("BookingDetail",
                                                                new XElement("ID", d.ID),
                                                                new XElement("BookingID", d.BookingId),
                                                                new XElement("OrderItem", d.OrderItem))).ToArray())).ToArray();
