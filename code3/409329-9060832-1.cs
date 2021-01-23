    context.ContextOptions.LazyLoadingEnabled = false;
    var user = context.Users.FirstOrDefault(u => u.UserId == 5);
    ((EntityCollection<Address>)user.Addresses)
         .CreateSourceQuery()
         .Where(a => !a.IsRowDeleted)
         .Execute();               
          
