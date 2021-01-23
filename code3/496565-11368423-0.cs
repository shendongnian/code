    // Now, open a database connection using the Microsoft.Jet.OLEDB provider.
    // The "using" statement ensures that the connection is closed no matter what.
    using (var connection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data      source=Northwind.mdb"))
    {
        connection.Open();
    // Create an OleDbDataAdapter and provide it with an INSERT command.
    var adapter = new OleDbDataAdapter();
    adapter.InsertCommand = new OleDbCommand("INSERT INTO Shippers (CompanyName, Phone) VALUES (@CompanyName , @Phone)", connection);
    adapter.InsertCommand.Parameters.Add("CompanyName", OleDbType.VarChar, 40, "CompanyName");
    adapter.InsertCommand.Parameters.Add("Phone", OleDbType.VarChar, 24, "Phone");
    adapter.Update(data);
    }    
