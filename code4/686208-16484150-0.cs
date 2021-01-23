     public class EntityBase 
    {
        
        #region DB Access
        public static MongoServer GetConnection()
        {
            return MongoDBHelper.GetConnection();
        }
        public static MongoDatabase GetDatabase()
        {
            return MongoDBHelper.GetDatabase();
        }
        public static MongoCollection<T> C<T>() where T : class
        {
            MongoCollection<T> col = GetDatabase().GetCollection<T>(typeof(T).Name);
            return col;
        }
        public static IQueryable<T> IQ<T>() where T : class
        {
            return C<T>().AsQueryable<T>();
        }
 
        #endregion
    }
