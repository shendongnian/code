    private void UpdateUsers(List<string> users) 
    {
        using(DBContext context = new DBContext("myConnectionString"))
        {
    	    foreach (var user in users) 
    	    {
                var u = from q in DBContext.Users
                    where q.Name == user 
                    select q; 
                u.IsActive = true;
            } 
        }
    }
