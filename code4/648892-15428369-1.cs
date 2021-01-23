    var user = SqlDataBase.SqlGetTable("select Id, Name from User where ...")
                          .AsEnumerable()
                          .ToList()
                          .Select(x => new UserViewModel { Id = x.Id, Name = x.Name })
                          .SingleOrDefault();
    
    int userId = user.Id;
    string username = user.Name;
