    private readonly MySqlConnection _conn = new MySqlConnection();
    private MySqlCommand _myCommand = new MySqlCommand();
    private readonly string _dbConn = ConfigurationManager.AppSettings["dbConn"];
    public void Closedb()
    {
        try
        {
            _conn.Dispose();
            _conn.Close();
        }
        catch (Exception ex)
        {
            
        }
    }
    
    public void UpdateDatabaseWithSql(string mysql)
    {
        Closedb();
        
            _conn.ConnectionString = _dbConn;
            _conn.Open();
        
        _myCommand= new MySqlCommand(mysql,_conn);
        _myCommand.ExecuteNonQuery();
        Closedb();
    }
