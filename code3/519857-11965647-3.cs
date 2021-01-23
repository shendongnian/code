    var users = Database.SqlQuery<Result>("exec sp_name", /*params*/)
        .Select(x=> new UserEntity
        {
            Date = DateTime.Parse(x.Date),
            Name = x.Name
        });
 
