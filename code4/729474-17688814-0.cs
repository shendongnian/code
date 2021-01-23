    public ICollection<Advertisment> favouriteAdvertismentsByUser(int UserID)
    {
        GetHiredDBContext db = new GetHiredDBContext();
    
        // First of all, you probably forgot to "include" FavouriteAdvertisments
        var users = db.Users.Include(u => u.FavouriteAdvertisments);
           
        // Second of all, use linq!
        return users.SingleOrDefault(u => u.UserID == UserID).FavouriteAdvertisments;
    }
