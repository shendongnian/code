    var users = DB.Users
        .Where(...) // Whatever filtering clause inside your query
        .AsEnumerable() // Force the query execution, switching to Linq to Objects
        .Select(user => new UserModel
        {
            id = user.id,
            firstname = user.firstname,
            lastname = user.lastname,
            dtContractStart = user.dtContractStart.ToString(),
            dtContractEnd = user.dtContractEnd.ToString(),
        })
        .ToList();
