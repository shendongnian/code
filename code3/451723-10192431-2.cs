    public static string GetLabel(string ProdRef)
    {
    	string strResult = null;
    	// create a new SqlConnection object with the appropriate connection string 
    	using (SqlConnection sqlConn = new SqlConnection("server=xxx;uid=yyy;pwd=zzz;database=myerp;"))
    	{
    		sqlConn.Open();
    		using (SqlCommand sqlComm = new SqlCommand("select libelle from dbo.vwArticlesPerm WHERE Ref = '" + ProdRef + "'", sqlConn))
    			strResult = (string)sqlComm.ExecuteScalar();
    		sqlConn.Close();
    		return strResult;
    	}
    }
