    SqlConnection myConn = new SqlConnection("Server=(local)\\netsdk;" + "uid=sa;pwd=;database=master");
    string str = "CREATE DATABASE MyDatabase ON PRIMARY " + 
        "(NAME = MyDatabase_Data, " + 
        " FILENAME = '" + Path.Combine(Application.StartupPath, "MyDatabaseData.mdf'") + 
        " SIZE = 2MB, " + " MAXSIZE = 10MB, " + " FILEGROWTH = 10%) " +
        " LOG ON " + "(NAME = MyDatabase_Log, " + 
        " FILENAME = '" + Path.Combine(Application.StartupPath, "MyDatabaseLog.ldf'") + ", " + 
        " SIZE = 1MB, " + " MAXSIZE = 5MB, " + " FILEGROWTH = 10%) ";
    SqlCommand myCommand = new SqlCommand(str, myConn);
    try
    {
        myConn.Open();
        myCommand.ExecuteNonQuery();
        MessageBox.Show("Database is created successfully", "MyProgram", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
    catch (Exception ex)
    {
        MessageBox.Show(ex.ToString());
    }
    finally
    {
        if ((myConn.State == ConnectionState.Open))
        {
            myConn.Close();
        }
    }
