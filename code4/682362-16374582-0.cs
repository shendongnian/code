    public class MyHelperClass
    {
        public static int InsertCommand(string sql, SQLiteParameter[] parameters)
        {
            int result = 0;
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            using (SQLiteCommand cmd = new SQLiteCommand(sql, connection))
            {
                cmd.Parameters.AddRange(parameters);
                result = cmd.ExecuteNonQuery();
            }  
            return result;
        }
    }
