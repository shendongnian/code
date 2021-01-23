    public ICollection<Advertisment> favouriteAdvertismentsByUser(User userEntity)
    {
        // Load the blog related to a given post
        GetHiredDBContext db = new GetHiredDBContext();
        db.Entry(userEntity).Reference(p => p.FavouriteAdvertisments).Load();
        
        return user.FavouriteAdvertisments;
    }
