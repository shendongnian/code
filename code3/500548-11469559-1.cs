    User user;
    using (var db = new Context())
    {
        user = db.Users.Where(...);
        // I guess you will need here:
        // .Include(u => u.Products)
    }
    var products = user.Products; // what error will you get here?
