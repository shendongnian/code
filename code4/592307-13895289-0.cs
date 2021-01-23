    string connectionString = @"Server=server\instance;Database=Northwind;Integrated Security=True";
    SqlConnection dataConnection = new SqlConnection(connectionString);
    try
    {
    dataConnection.Open();
    }
    catch (sqlexception e)
    {
    Messagebox.Show("Error");
    }
