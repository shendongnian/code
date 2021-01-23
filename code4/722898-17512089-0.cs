    public static DataTable SqlDataTable(SqlCommand cmd)
    {
        using (SqlConnection conn = new SqlConnection(DatabaseConnectionString))
        {  
            cmd.Connection = conn;   // store your connection to the command object..
            cmd.Connection.Open();
            DataTable TempTable = new DataTable();
            TempTable.Load(cmd.ExecuteReader());
            return TempTable;
        }
    }
    
    public DataTable GetMyCustomers(string likeName)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "select * from SomeTable where LastName like "@someParm%";
        cmd.Parameters.Add( "whateverParm", likeName );  // don't have SQL with me now, guessing syntax
    
        // so now your SQL Command is all built with parameters and ready to go.
        return SqlDataTable( cmd );
    }
