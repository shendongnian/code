    OleDbConnection cn = new OleDbConnection();
    OleDbCommand cmd = new OleDbCommand();
    DataTable schemaTable; 
    OleDbDataReader myReader; 
    			 
    //Open a connection to the SQL Server Northwind database.
    cn.ConnectionString = "Provider=SQLOLEDB;Data Source=server;User ID=login;
                           Password=password;Initial Catalog=Northwind";
    cn.Open();
    
    //Retrieve records from the Employees table into a DataReader.
    cmd.Connection = cn;
    cmd.CommandText = "SELECT * FROM tblAccount WHERE [Account ID] = 2343 LIMIT 0, 1";
    myReader = cmd.ExecuteReader(CommandBehavior.KeyInfo); 
    
    //Retrieve column schema into a DataTable.
    schemaTable = myReader.GetSchemaTable();
    ...
