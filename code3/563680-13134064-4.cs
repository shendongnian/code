    static partial class Db
    {
        static IDb db = Utility.GetDbInstance();
        public static R? ExecuteAndGet<R>(string query, 
                                          Dictionary<string, object> parameters, 
                                          out string possibleError) where R : struct
        {
            return db.ExecuteAndGet<R>(query, parameters, out possibleError);
        }
        public static bool Execute(string query, 
                                   Dictionary<string, object> parameters, 
                                   out string possibleError)
        {
            return db.Execute(query, parameters, out possibleError);
        }
        public static DataTable Read(string query, 
                                     Dictionary<string, object> parameters, 
                                     out string possibleError)
        {
            return db.Read(query, parameters, out possibleError);
        }
    }
