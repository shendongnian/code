    public static ObjectDataSource CreateObjectDataSource()
    {
       var obj = new ObjectDataSource();
       obj.Deleted  += OnDeleted; //function for handling event
       ...
    
       return obj;
    }
