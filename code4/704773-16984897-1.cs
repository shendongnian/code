    public IEnumerable<T> ExecuteSelect<T>(DbContext context, string table)
    {
         IEnumerable<T> entities = context.Set<T>.SqlQuery("SELECT * FROM " + table).ToList();
    
         return entities;
    }
