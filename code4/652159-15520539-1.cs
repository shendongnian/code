    private SqlConnection _baseConnection;
    public SqlConnection BaseConnection
    {
        get { return _baseConnection = _baseConnection ?? new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString); }
    }
