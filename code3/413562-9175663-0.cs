    public List<String> GetListNameUsers()
    {
    
     using (var context = new UCDataContext())
     {
         var users = (from c in context.Users.ToList()
                 select (c.LastName + " " + c.FirstName) ).ToList();
     }
    
    }
