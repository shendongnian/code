    string ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Path\Book81.xlsx;Extended Properties=Excel 8.0;";
    OleDbConnection ExcelConnection = new OleDbConnection(ConnectionString);
    ExcelConnection.Open();
    string update = "UPDATE [Sheet1$] SET Name='Smith Jones' where name='Smith'";
    OleDbCommand UpdateCommand = new OleDbCommand(update, ExcelConnection);
    UpdateCommand.ExecuteNonQuery();
