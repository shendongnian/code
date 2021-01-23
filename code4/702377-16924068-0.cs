    public static myDBEntities getDBContext(String connectionString) {   
        myDBEntities DB = new myDBEntities();
        DB.Database.Connection.ConnectionString = connectionString;
        return DB;
    }
