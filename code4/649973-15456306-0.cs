     if(User.IsInRole("admin"))
        return _db.Items;
     else 
     {
        string name = User.Identity.Name;
        return _db.Items.Where(d => d.CreatedBy.Equals(name)));
     }
