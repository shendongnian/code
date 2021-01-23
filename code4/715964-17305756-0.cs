    public void ClearTableCache(string tableName) 
    {
        lock (System.Web.HttpContext.Current) 
        {
           System.Web.HttpContext.Current.Application[tableName] = null;
        }        
    }
    public SomeDataType GetTableData(string tableName) 
    {
        lock (System.Web.HttpContext.Current) 
        {
           if (System.Web.HttpContext.Current.Application[tableName] == null) 
           {
              //get data from DB then put it into application state
              System.Web.HttpContext.Current.Application[tableName] = dataFromDb;
              return dataFromDb;
           }
           return (SomeDataType)System.Web.HttpContext.Current.Application[tableName];
        }            
    }
