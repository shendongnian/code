    public static IEnumerable<string> getList
    {
       get
       {
           return store.AsReadonly();
       }
    }
