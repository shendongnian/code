    public static string DB_NAME = "mydb"; //you don't need an extension here, this is the db name not a filename
    public static string DB_PATH = "C:\\data\\";
    public bool CreateDatabase()
    {
        bool stat=true;
        string sqlCreateDBQuery;
        SqlConnection myConn = new SqlConnection("Server=localhost\\SQLEXPRESS;Integrated security=SSPI;database=master;");
        sqlCreateDBQuery = " CREATE DATABASE "
                            + DB_NAME
                            + " ON PRIMARY "
                            + " (NAME = " + DB_NAME + "_Data, "
                            + " FILENAME = '" + DB_PATH + DB_NAME + ".mdf', "
                            + " SIZE = 2MB,"
                            + " FILEGROWTH = 10%) "
                            + " LOG ON (NAME =" + DB_NAME + "_Log, "
                            + " FILENAME = '" + DB_PATH + DB_NAME + "Log.ldf', "
                            + " SIZE = 1MB, "
                            + " FILEGROWTH = 10%) ";
        SqlCommand myCommand = new SqlCommand(sqlCreateDBQuery, myConn);
        try
        {
            myConn.Open();
            myCommand.ExecuteNonQuery();
        }
        catch (System.Exception)
        {
            stat=false;
        }
        finally
        {
            if (myConn.State == ConnectionState.Open)
            {
                myConn.Close();
            }
            myConn.Dispose();
        }
        return stat;
    }
