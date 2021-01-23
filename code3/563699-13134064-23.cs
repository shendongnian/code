    public static class Db
    {
        static IDb db = Utility.GetDbInstance();
        public static T? ExecuteAndGet<T>(string query, 
                                          Dictionary<string, object> parameters, 
                                          out string possibleError) where T : struct
        {
            return db.ExecuteAndGet<T>(query, parameters, out possibleError);
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
