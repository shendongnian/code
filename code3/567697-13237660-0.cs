    public LampPostDetail getLamppostInfo(int id,OvisionDBEntities context)
    {
    ...
        try
        {
           OvisionDBEntities db;
           if (context == null)
              db = new OvisionDBEntities();
           else
              db = context;
        ...
        }
        finally
        {
           if (context == null && db != null)
             db.Dispose() // or close maybe
        }
        
        retun lpd;
     }
     // Overloaded function to keep orignal functionality (C# 3.5 does not have 
     // optional parameters)
     public LampPostDetail getLamppostInfo(int id)
     {
         return LampPostDetail(id,null)
     }
