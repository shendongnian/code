    var query = (from bwl in mg.BarcodeWithLocation
                  where(c=>c.ReceivedDate > DateTime.Now.AddDays(-7))
                             select new
                             {
                                 RequestID = bwl.RequestID,
                                 Barcode = bwl.Barcode,
                                 adrid = bwl.AdrID,
                                 name = bwl.Name,
                                 street = bwl.Street,
                                 houseno = bwl.HouseNo,
                                 postal = bwl.Postal,
                                 city = bwl.City,
                                 country = bwl.Country,
                                 latitudetxt = bwl.Latitude == "" ? "Location Unknown" : "View Map Location",
                                 latitude = bwl.Latitude,
                                 longitude = bwl.Longitude,
                                 date = bwl.ReceivedDate
                             });
