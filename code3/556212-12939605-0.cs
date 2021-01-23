    public class MyObject
    {
        public int UserID {get;set;}
        public List<SomeObjects> {get;set;}
        public List<SomeOtherObjects {get;set}
    
        public MyObject(int TheUserID)
        {
            this.UserID = TheUserID;
        }
    
        public static MyObject LoadTheObjectFromDatabase()
        {
            MyQueries TheQueries = new MyQueries();
            MyObject TheObjectForDB = TheQueries.LoadFromDB(UserID) //HERE: object for DB work
    
            return TheObjectForDB;
        }
    }
