    public ICollection<Advertisment> favouriteAdvertismentsByUser(int UserID)
    {
        return new GetHiredDbContext()
            .Users
            .Single(u => u.UserID = UserID)
            .FavouriteAdvertisements;
    }
