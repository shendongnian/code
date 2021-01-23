    using System.Data;
    using System.Data.OleDb;
    string myConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;" +
                               "Data Source=C:\myPath\myFile.mdb;" +                                    
                               "Persist Security Info=True;" +
                               "Jet OLEDB:Database Password=myPassword;";
    try
    {
        // Open OleDb Connection
        OleDbConnection myConnection = new OleDbConnection();
        myConnection.ConnectionString = myConnectionString;
        myConnection.Open();
        // Execute Queries
        OleDbCommand cmd = myConnection.CreateCommand();
        cmd.CommandText = "SELECT * FROM `myTable`";
        OleDbDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection); // close conn after complete
        // Load the result into a DataTable
        DataTable myDataTable = new DataTable();
        myDataTable.Load(reader);
    }
    catch (Exception ex)
    {
        Console.WriteLine("OLEDB Connection FAILED: " + ex.Message);
    }
