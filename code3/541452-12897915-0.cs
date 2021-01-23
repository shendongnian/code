    class MyContext: DbContext
    {
       public DBSet<Some_Entity_Which_Represent_DB_table> SetName {get;set;}
    
       public MyContext() : base(here you can specify database with its name or connectionString or leave it empty)
       {}
    }
