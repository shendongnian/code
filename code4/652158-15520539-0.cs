    private SqlConnection _baseConnection;
    public SqlConnection baseConnection
    {
        get { return _baseConnection = _baseConnection ?? new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString); }
    }
