    class BlDb : DbManager
    {
        public BlDb()
            : base( new BLToolkit.Data.DataProvider.MySqlDataProvider(), "Server=myServerAddress;Database=myDataBase;Uid=myUsername;Pwd=myPassword" )
        {           
        }
        public Table<Car> Car { get { return GetTable<Car>(); } }
        public Table<Make> Make { get { return GetTable<Make>(); } }
    }
