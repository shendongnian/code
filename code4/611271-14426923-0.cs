    protected void SaveEntity<T>(T entity)
        where T : class
    {
        using (DocsManagerContainer context = new DocsManagerContainer())  
        {  
            DbTransaction transaction = null;  
            try  
            {  
                context.Connection.Open();  
                transaction = context.Connection.BeginTransaction();  
                context.Set<T>().Add(entity);  
                transaction.Commit();  
                context.SaveChanges();  
            }  
            finally  
            {  
                context.Connection.Close();  
                    transaction = null;  
            }
        }
    }
