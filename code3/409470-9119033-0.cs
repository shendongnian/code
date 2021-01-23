    string DATABASE_PROVIDER = "Provider=Microsoft.ACE.OLEDB.12.0";
    string CVS Application.StartupPath + ""\\Database.accdb";
    string DATA_SOURCE = "Data Source" + CVS;
    string connectionString = DATABASE_PROVIDER + DATA_SOURCE;
    string TABLE = " FROM STUFF";
    string SELECT = "SELECT CODE, NAME, ICON, FUNCTION;
    string StringQueryCmd = SELECT + TABLE;
    
    OleDbConnection MyConnection = new OleDbConnection(connectionString);
    OleDbCommand Command = OleDbCommand(StringQueryCmd,MyConnection);
    OleDbAdapter MyDataAdapter = new OleDbAdapter(Command);
    DataSet MyDataSet = new DataSet();
    DataTable MyDataTable = new DataTable();
    MyConnection.Open();
    MyDataAdapter.Fill(MyDataSet,"STUFF");
    MyConnection.Close();
