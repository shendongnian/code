    public List<iClean.Booking> GetBookings()
    {
        List<iClean.Booking> bookings = new List<iClean.Booking>();
        ArrayList records = this.Select("Bookings", "");
        iClean.Booking tempBooking = new iClean.Booking();
        for (int i = 0; i < records.Count; i++)
        {
            tempBooking = new iClean.Booking();
            Hashtable row = (Hashtable)records[i];
            tempBooking.ID = Convert.ToInt32(row["ID"]);
            tempBooking.Name = Convert.ToString(row["ClientName"]);
            tempBooking.Address = Convert.ToString(row["ClientAddress"]);
            tempBooking.Phone = Convert.ToString(row["ClientPhone"]);
            tempBooking.DueDate = Convert.ToDateTime(row["Bookingdate"]);
            tempBooking.Completed = Convert.ToBoolean(row["Completed"]);
            tempBooking.Paid = Convert.ToBoolean(row["Paid"]);
            tempBooking.Cancelled = Convert.ToBoolean(row["Cancelled"]);
            tempBooking.ReasonCancelled = Convert.ToString(row["ReasonCancelled"]);
            tempBooking.ContractorPaid = Convert.ToBoolean(row["ContractorPaid"]);
            tempBooking.Comments = Convert.ToString(row["Comments"]);
            tempBooking.Windows = Convert.ToBoolean(row["Windows"]);
            tempBooking.Gardening = Convert.ToBoolean(row["Gardening"]);
            tempBooking.IndoorCleaning = Convert.ToBoolean(row["IndoorCleaning"]);
            bookings.Add(tempBooking);
        }
        return bookings;
    }
