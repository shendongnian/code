    public ICollection<Advertisment> favouriteAdvertismentsByUser(int userID)
    {
        GetHiredDBContext db = new GetHiredDBContext();
        User myUser = db.Users
                        .Where(x => x.UserID = userID)
                        .Include(x => x.FavouriteAdvertisments)
                        .FirstOrDefault();
        return myUser.FavouriteAdvertisments;
    }
