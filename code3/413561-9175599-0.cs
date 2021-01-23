    public List<String> GetListNameUsers()
    {
    
     using (var context = new UCDataContext())
     {
         return context.Users
                       .Select(c=>new {c.LastName, c.FirstName})
                       .ToList()
                       .Select(c=>c.LastName + " " + c.FirstName)
                       .ToList();
     }
    
    }
