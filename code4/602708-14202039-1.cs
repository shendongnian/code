    class DataHelper
    {
        public MyDatabaseDataContext db = new MyDatabaseDataContext();
    
        List<dynamic> GetDynamicList<T>() where T : class
        {
            System.Data.Linq.Table<T> table = db.GetTable<T>();
                
            var result = from a in table select a;
                
            return result.ToList<dynamic>();
        }
    
        public List<dynamic> GetWhatIWant(string tableName)
        {
            Type myClass = Type.GetType("DynamicLinqToSql." + tableName);
            MethodInfo method = typeof(DataHelper).GetMethod("GetDynamicList", BindingFlags.NonPublic | BindingFlags.Instance);
            method = method.MakeGenericMethod(myClass);
            return (List<dynamic>)method.Invoke(this, null);
        }
    }
