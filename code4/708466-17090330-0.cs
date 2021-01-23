    #region "Properties"
    public string sql { get; protected set; }
    public CommandType cType { get; protected set; }
    public List<MySqlParameter> args { get; protected set; }
    public string rValue { get; protected set; }
    private MySqlConnection conn;
    private string server = "127.0.0.1";
    private string database = "stman";
    private string user = "root";
    private string password = "root";
    #endregion
    #region "Constructor Logic"
        public Database(string CommandText, CommandType CommandType, List<MySqlParameter> Parameters, string ReturnParameter = "")
        {
            buildConnection();
            sql = CommandText;
            cType = CommandType;
            args = Parameters;
            rValue = ReturnParameter;
        }
        public Database(string CommandText, CommandType CommandType)
        {
            buildConnection();
            sql = CommandText;
            cType = CommandType;
        }
        private void buildConnection()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(String.Format("data source={0}; initial catalog={1}; user id={2}; password={3};", server, database, user, password));
            conn = new MySqlConnection(sb.ToString());
        }
    #endregion
    public DataTable GetDataTable()
    {
        DataTable dt = new DataTable();
        MySqlDataAdapter da = new MySqlDataAdapter();
        using (MySqlCommand cmd = new MySqlCommand(sql, conn))
        {
            if (args.Count > 0)
            {
                cmd.Parameters.AddRange(args.ToArray());
            }
            cmd.CommandType = cType;
            da.SelectCommand = cmd;
            da.Fill(dt);
        }
        if (dt.Rows.Count > 0)
        {
            return dt;
        }
        else
        {
            return null;
        }
    }
