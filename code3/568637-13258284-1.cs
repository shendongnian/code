    public int GetRentDays(int memberID, string movieID)
    {      
        var movieRentDays = videoLibDB.Rents.FirstOrDefault
            (r => r.MemberID == memberID && r.MovieID == movieID);
        return movieRentDays == null || movieRentDays.HasValue ? 0 
            : movieRentDays.RentDays.Value;
    }
