    var query = Repository.All().Where(*/ some criteria */).Take(2).ToList(); //magic here
    
    if (query.Count == 0) {
        // handle empty return
    } else if (query.Count > 1) {
        // handle unexpected returns
    }
    
    return query.Single();
