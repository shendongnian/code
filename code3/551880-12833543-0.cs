	private string retrieveList(string SalCode, string groupKeyword, string text)
	{
	    SqlConnection _sqlCon = default(SqlConnection);
	    SqlCommand _sqlCom = default(SqlCommand);
	    SqlDataReader _sqlReader = default(SqlDataReader);
	    StringBuilder _sb = new StringBuilder();
	    List<TokenInputJSON> _out = null;
	
	    try
	    {
	        _sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SalesianBlastConnectionString"].ConnectionString);
	        _sqlCom = new SqlCommand("getTokenInput", _sqlCon);
	        _sqlCom.CommandType = CommandType.StoredProcedure;
	        _sqlCon.Open();
	        
	        //This is the edited part
	        if(SalCode==null || SalCode.Equals("")) {
	        	_sqlCom.Parameters.Add(new SqlParameter("@salCode", SqlDbType.VarChar, 4)).Value = SalCode;
	        }
	        //... continue with the other parts
