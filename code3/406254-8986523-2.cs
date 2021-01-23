    var user = context.Users.Where(c => c.UserID == FormPostID).SingleOrDefault(); 
    foreach (Family f in user.Familys)
    {
        if (f.FamilyName == "Flintstone")
        {
            // This works
        }
    }
    
