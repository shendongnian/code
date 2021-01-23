    public static struct ConnectionString
    {
        public int ID;
        public string Connection;
        public override string ToString()
        {
            return Connection;
        }
       public static ConnectionString DataBase1 = new ConnectionString{ ID = 1 , Connection = "YourConnectionStringhere"};
       public static ConnectionString DataBase2 = new ConnectionString{ ID = 2 , Connection = "YourConnectionString2here"};
    }
