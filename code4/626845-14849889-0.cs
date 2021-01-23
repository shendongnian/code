    BookingUpdate[] bookingupdate = dt.AsEnumerable()
        .Select(r => new BookingUpdate{
            bookingID = r.Field<long>("ID"),
            fullUserName = r.Field<string>("VERANSTALTER"),
            newStart = r.Field<DateTime>("Von"),
            newEnd = r.Field<DateTime>("Bis"), // here was another bug in your originalcode
            newSubject = r.Field<string>("THEMA"),
            newlocation = r.Field<string>("BEZEICHNUNG"),
            deleted = r.Field<string>("STORNO") != null
        })
        .ToArray();
