    using System.Data;
    using System.Data.OleDb;
    string connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;" +
                               "Data Source=C:\myPath\myFile.mdb;" +                                    
                               "Persist Security Info=True;" +
                               "Jet OLEDB:Database Password=myPassword;";
    try
    {
        // Open OleDb Connection
        OleDbConnection myQuikCalcConnection = new OleDbConnection();
        myQuikCalcConnection.ConnectionString = connectionString;
        myQuikCalcConnection.Open();
        // Execute Queries
        OleDbCommand cmd = myQuikCalcConnection.CreateCommand();
        cmd.CommandText = "SELECT * FROM `myTable`";
        OleDbDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection); // close conn after complete
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                // Get data from OleDbDataReader
                Console.WriteLine("{0}\t{1}", reader.GetInt32(0), reader.GetString(1));
            }
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine("OLEDB Connection FAILED: " + ex.Message);
    }
