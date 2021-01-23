	class dataContext:DataContext
    {
        public dataContext(string connectionString): base(connectionString)
         {
         }
        //1------------
        public Table<account> accountees
        {
            get
            {
                return this.GetTable<account>();
            }
        }
        //2--------------
         public Table<messages> messagees
         {
         get
         {
         return this.GetTable<messageCategory>();
         }
         }
        //3---------------
         public Table<test> testees
         {
             get
             {
                 return this.GetTable<testCategory>();
             }
         }
    }
