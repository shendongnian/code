    private AMTEntitiesContainer context = new AMTEntitiesContainer();
    
    public IEnumerable<Users> getUsersByLastName(string pLastName)
    {
        IQueryable<Users> results;
               
        results = (from m in context.Users
                   where m.LastName.StartsWith(pLastName)
                   select m);
                                
        return results;
    }
