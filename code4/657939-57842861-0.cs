    public abstract class BaseSQLiteAccess
    {
        protected SQLiteConnection _databaseConnection;
        protected String TableName { get; set; }
    
        //...
        protected bool RowExists(int id) 
        {
            bool exists = false;
            try
            {
                exists = _databaseConnection.ExecuteScalar<bool>("SELECT EXISTS(SELECT 1 FROM " + TableName + " WHERE ID=?)", id);
            }
            catch (Exception ex)
            {
                //Log database error
                exists = false;
            }
            return exists;
        }
    }
