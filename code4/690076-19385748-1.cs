    con = new SqlConnection("context connection=true");
    con.Open();
    using (con)
    {
    	using (var sqlTrans = con.BeginTransaction()) //one transaction instead of many from each insert implicit
    	{
    		const string cmdText = @"INSERT INTO [table1] ([a],[b],[c],[d],[e]) VALUES (@a,@b,@c,@d,@e)";
    		using (var cmd = new SqlCommand(cmdText, con, sqlTrans))
    		{
    			var aField = cmd.Parameters.Add("@a", SqlDbType.NVarChar, 255);
    			var bField = cmd.Parameters.Add("@b", SqlDbType.Int);
    			var cField = cmd.Parameters.Add("@c", SqlDbType.Bit);
    			var dField = cmd.Parameters.Add("@d", SqlDbType.NVarChar, 255);
    			var eField = cmd.Parameters.Add("@e", SqlDbType.Int);
    
    			//same for all
    			cField.Value = false;
    			dField.Value = "d";
    			eField.Value = 1;
    
    			foreach (var someValue in valueCollection)
    			{
    				aField.Value = someValue.Key; 
    				bField.Value = someValue.Value; 
    				cmd.ExecuteNonQuery();
    			}
    		}
    		sqlTrans.Commit();
    	}
    	con.Close();
    }
