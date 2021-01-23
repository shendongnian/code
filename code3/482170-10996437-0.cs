    public abstract class MyDBManager
    {
        public abstract bool OpenConnetion();
        public abstract DataTable OpenDataTable(); // For select queroes
        public abstract int ExecuteNonQuery(string qry) // for insert/delete queries
        public abstract bool CloseConnection();
    }
    public class MySQLCEManger : MyDBManager
    {
        public bool OpenConnection() 
        { 
            // your sqlce connection
        }
        public DataTable OpenDataTable(string query)
        {
             //Open connection
             //execute query and return datatable
             //Close connection
        }
    }
     public class MySQLManager : MySQLCEManager
     {
        public bool OpenConnection() 
        { 
            // your sql cen connection
        }
        public DataTable OpenDataTable(string query)
        {
             if(!OpenConnection())  //failed to open connection
                 return base.OpenDataTable();
             //execute query and return datatable
             //Close connection
        }
        public int ExecuteNonQuery(string query)
        {
             if(!OpenConnection())  //failed to open connection
                 return base.ExecuteNonQuery();
             //execute query and return rows affected
             //Close connection
        }
    }
