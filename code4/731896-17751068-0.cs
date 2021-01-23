            public static int SpecialDelete(DataContext db, IEnumerable<BookingType> bookings)
            {
                var compositeKeys = bookings.Select(b => b.Pren.ToString() + b.ReservationCode).Distinct();
                IEnumerable<BookingType> bookingsToDelete = db.GetTable<BookingType>().Where(b => compositeKeys.Contains(b.Pren.ToString() + b.ReservationCode));
    
                int deleted = bookingsToDelete.Count();
                db.GetTable<BookingType>().DeleteAllOnSubmit(bookingsToDelete);
                db.SubmitChanges();
    
                return deleted;
            }
