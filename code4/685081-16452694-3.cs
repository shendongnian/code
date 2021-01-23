    #region DataSet, DataAdapter, DataTable
    internal DataSet dataSet;
    internal OleDbDataAdapter dataAdapter;
    internal DataTable dataTable;
    private OleDbConnection connection;
    #endregion
    
    internal GetData(string SelectQuery, string ConnectionString)
    {
        try
        {
            #region Create Data Objects: Connection, DataAdapter, DataSet, DataTable
            // use OleDb Connection to MS Access DB
            connection = new OleDbConnection(ConnectionString);
            connection.Open();
    
            // create new DataAdapter on OleDb Connection and Select Query text
            dataAdapter = new OleDbDataAdapter();
            dataAdapter.SelectCommand = new OleDbCommand(SelectQuery, connection);
    
            // create DataSet
            dataSet = new DataSet();
    
            // retrieve TableSchema
            // DataTable[] _dataTablesSchema = _dataAdapter.FillSchema(_dataSet, SchemaType.Source, "{TABLE NAME}");
            DataTable[] _dataTablesSchema = dataAdapter.FillSchema(dataSet, SchemaType.Source);
    
            // there is only one Table in DataSet, so use 0-index
            dataTable = _dataTablesSchema[0];
    
            // use DataAdapter to Fill Dataset
            dataAdapter.Fill(dataTable);
    
            // OPTIONAL: use OleDbCommandBuilder to build a complete set of CRUD commands
            OleDbCommandBuilder builder = new OleDbCommandBuilder(dataAdapter);
            // Update, Insert and Delete Commands
            dataAdapter.UpdateCommand = builder.GetUpdateCommand();
            dataAdapter.InsertCommand = builder.GetInsertCommand();
            dataAdapter.DeleteCommand = builder.GetDeleteCommand();
            #endregion
    
            connection.Close();
        }
        catch {throw; }
    }
