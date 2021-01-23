    public List<T> GetDataNoParams(string procname)
    {
       var query = this.ExecuteQuery<T>("Exec " + procname);
    
       return query.ToList();
    }
    public List<T> GetDataParams(string procname, Object[] parameters)
    {
       var query = this.ExecuteQuery<T>("Exec " + procname, parameters);
    
       return query.ToList();
    }
