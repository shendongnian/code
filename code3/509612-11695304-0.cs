    List<BALHotelList> searchresult= (from a in bh
                join b in hr on a.HotelCode equals b.hotelCode
                orderby a.HotelName
                select new BALHotelList
                    {
                       HotelCode= a.HotelCode,
                       ImageURL_Text = a.ImageURL_Text,
                       HotelName = a.HotelName,
                       StarRating = a.StarRating,
                       HotelAddress = a.HotelAddress,
                       Destination = a.Destination,
                       Country = a.Country,
                       HotelInfo = a.HotelInfo,
                       Latitude = a.Latitude,
                       Longitude = a.Longitude,
                       totalPrice = b.totalPrice,
                       totalPriceSpecified = b.totalPriceSpecified,
                       totalSalePrice = b.totalSalePrice,
                       totalSalePriceSpecified = b.totalSalePriceSpecified,
                       rooms = b.rooms
                    }).Tolist();
