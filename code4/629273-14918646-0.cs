    private OleDbConnection conn = new OleDbConnection();
    private string _strCon = ConfigurationManager.ConnectionStrings["OracleDBConnString"].ConnectionString;
    private OleDbTransaction _trans = null;
    DataTable dt = new DataTable();
    DataSet ds = new DataSet();
    OleDbDataAdapter da = new OleDbDataAdapter();
    
    conn.Open();
    
    strSelectQuery = "SELECT last(call_no) FROM tbl_IThelpdesk"; // here you have to put your query
    
    
    da.SelectCommand = new OleDbCommand(strSelectQuery, conn);
    da.Fill(ds);
    dt = ds.Tables[0];
    
    conn.Close();
