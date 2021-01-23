    //The connection strings needed: One for SQL and one for Access
    String accessConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\...\\test.accdb;";
    String sqlConnectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=Your_Catalog;Integrated Security=True";   
    //Make adapters for each table we want to export
    SqlDataAdapter adapter1 = new SqlDataAdapter("select * from Table1", sqlConnectionString);
    SqlDataAdapter adapter2 = new SqlDataAdapter("select * from Table2", sqlConnectionString);
        
    //Fills the data set with data from the SQL database
    DataSet dataSet = new DataSet();
    adapter1.Fill(dataSet, "Table1");
    adapter2.Fill(dataSet, "Table2");
    //Create an empty Access file that we will fill with data from the data set
    ADOX.Catalog catalog = new ADOX.Catalog();
    catalog.Create(accessConnectionString);
    //Create an Access connection and a command that we'll use
    OleDbConnection accessConnection = new OleDbConnection(accessConnectionString);
    OleDbCommand command = new OleDbCommand();
    command.Connection = accessConnection;
    command.CommandType = CommandType.Text;
    accessConnection.Open();
    //This loop creates the structure of the database
    foreach (DataTable table in dataSet.Tables)
    {
        String columnsCommandText = "(";
        foreach (DataColumn column in table.Columns)
        {
            String columnName = column.ColumnName;
            String dataTypeName = column.DataType.Name;
            String sqlDataTypeName = getSqlDataTypeName(dataTypeName);
            columnsCommandText += "[" + columnName + "] " + sqlDataTypeName + ",";
        }
        columnsCommandText = columnsCommandText.Remove(columnsCommandText.Length - 1);
        columnsCommandText += ")";
    
        command.CommandText = "CREATE TABLE " + table.TableName + columnsCommandText;
    
        command.ExecuteNonQuery();
    }
    //This loop fills the database with all information
    foreach (DataTable table in dataSet.Tables)
    {
        foreach (DataRow row in table.Rows)
        {
            String commandText = "INSERT INTO " + table.TableName + " VALUES (";
            foreach (var item in row.ItemArray)
            {
                commandText += "'"+item.ToString() + "',";
            }
            commandText = commandText.Remove(commandText.Length - 1);
            commandText += ")";
    
            command.CommandText = commandText;
            command.ExecuteNonQuery();
        }
    }
    
    accessConnection.Close();
