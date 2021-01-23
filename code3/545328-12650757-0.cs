    string c = Application.StartupPath + "\\Stock.mdf";
    string connectionString = @"AttachDbFilename='"+c+"';Integrated Security=True;Connect Timeout=30;User Instance=True";
    using (SqlConnection connection = new SqlConnection(connectionString))
    	{
    	    con.Open();
    	    using (SqlCommand command = new SqlCommand(Insert into Codedetails values('TF','@productcode','@productname','@brandcode','@brandname'), con))
    	        {		
    		command.Parameters.Add(new SqlParameter("productcode", txt_productcode.Text));
    		command.Parameters.Add(new SqlParameter("productname", txt_productcode.Text));
    		command.Parameters.Add(new SqlParameter("brandcode", txt_brandcode.Text));
    		command.Parameters.Add(new SqlParameter("brandname", txt_brandname.Text));
    		command.ExecuteNonQuery();
    		}
    	}
    
     
