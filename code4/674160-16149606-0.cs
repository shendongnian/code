      public static DataTable FetchOrCreate(this DataSet ds, string tableName)
      {
           if (ds.Tables.Contains(tableName)) 
               return ds.Tables[tableName];
           // -------------------------------
           var dt = new Datatable(tableName);
           ds.Tables.Add(dt);
           return dt;          
      }
