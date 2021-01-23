    IQueryable<User> query = Users.Where(x => x.LineManagerId == id);
    bool isManager = query.Any(); // first query to check if manager
    if(isManager){
       IEnumerable<User> users = query.Select(x => x.Id).ToArray(); // second query to fetch Ids
    }
