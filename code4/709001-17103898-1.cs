    var ll;
    using (var db = new DB())
    {
        ll = from x in db.Users 
                 join y in db.UserPartners on x.ID equals y.ID
                 join z in db.UserFriends on x.ID equals z.ID
                 select new { Users = x, UserPartners = y, UserFriends = z };
    }
    if (!String.IsNullOrEmpty(fulltext))
    {
        var AllSearchField = Utils.GetAllColumnsFromEntity(new User(), new UserPartner(), new UserFriends());
        //TODO:
        //Here i need a code, which generate predicate for all text fields in tables
        //the result would be like :
        foreach (var source in ll.Where(a => a.Users.Address.Contains(fulltext) || a.Users.Email.Contains(fulltext) || a.UserPartners.Email.Contains(m.FullText)))
        {
            // do something with source    
        }
    }
