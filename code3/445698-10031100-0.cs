    var query = edmxObject.Users;
    
    if (! String.IsNullOrEmpty(model.FirstName)) {
        query = from user in query
                where user.FirstName.Contains(model.FirstName)
                select query;
    }
    if (! String.IsNullOrEmpty(model.UserName) {
        query = from user in query
                where user.UserName.Contains(model.UserName)
                select query;
    }
    // this will cause the query to execute get the materialized results
    var result = query.ToList();
