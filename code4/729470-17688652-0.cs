    {
        // Load the blog related to a given post
        GetHiredDBContext db = new GetHiredDBContext();
        foreach (User user in db.Users)
        {
            if (user.UserID == UserID)
            {
                db.Entry(user).Reference(p => p.FavouriteAdvertisments).Load();
                return user.FavouriteAdvertisments;
            }
        }
        return null;
    }
