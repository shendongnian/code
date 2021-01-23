    public IList<Category> GetCategoriesByUsername(string username)
    {
        User uAlias = null;
    
        var categories = SessionFactory.GetCurrentSession().QueryOver<Category>(() => cAlias)
        .Fetch(x => x.Keywords ).Eager
        .JoinAlias(() => cAlias.User, () => uAlias)
        .Where(() => uAlias.Username == username);
        
    
        IList<Category> list = (List<Category>)categories.ToList();   
        return list;
    }
    public IList<Category> GetCategoriesByUsername(string username)
    {
        User uAlias = null;
        Keyword kAlias = null;
    
        var categories = SessionFactory.GetCurrentSession().QueryOver<Category>(() => cAlias)
        .JoinAlias(() => cAlias.User, () => uAlias)
        .JoinAlias(x => x.Keywords , () => kAlias, JoinType.LeftOuterJoin)
        .Where(() => uAlias.Username == username);
        
    
        IList<Category> list = (List<Category>)categories.ToList();   
        return list;
    }
