    bool isNew = false;
    var data = context.Accounts.Where(a => a.UserName == User.Identity.Name).Select(a => a.UserAddons).SingleOrDefault();
    if (data == null)
    {
       data = new UserAddons();
       isNew = true;
    }  
    // setting up properties of data
    if(isNew)
        context.Add(data);
    context.SaveChanges();
