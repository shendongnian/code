    IQueryable<User> query = entities.Users;
    switch (userField)
    {
        case "ID":
            int searchID;
            if (int.TryParse(searchText, out searchID))
                query = query.Where(u => u.ID == searchID);
            else
                query = query.Where(u => false);
            break;
        case "Name":
            query = query.Where(u => u.Name == searchText);
            break;
        case "Email":
            query = query.Where(u => u.Email == searchText);
            break;
    }
    var users = new
    {
        total = 10,
        page = page,
        record = (entities.Users.Count()),
        rows = (from user in query
                select new
                // etc.
               )
    };
