        string sConnString = System.Configuration.ConfigurationManager.ConnectionStrings["ConString1"].ConnectionString;
        using(SqlConnection mySqlCon = new SqlConnection(sConnString))
    	{
    		using(SqlCommand mySqlCom = new SqlCommand())
    		{
    			mySqlCom.Connection = mySqlCon;
    			mySqlCom.CommandText = "pr_Update";
    			mySqlCom.CommandType = CommandType.Text;
    			mySqlCom.Parameters.Add("@UserID", SqlDbType.VarChar, 20).Value = UserID;
    			mySqlCom.Parameters.Add("@Nominated", SqlDbType.Bit).Value = Nominated;
    			try
    			{
    				mySqlCon.Open();
    				mySqlCom.ExecuteNonQuery();
    			}
    			catch(SqlException ex)
    			{
    				// do something with the exception
    				// don't hide it
    			}
    			
    		}
    	}
