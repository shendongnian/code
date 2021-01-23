		using(SqlConnection SqlCon = new SqlConnection(GetConnectionString()) {
			var sqlString = "SELECT u.UserID, c.CompanyID FROM User_Info u LEFT JOIN Company_Info c ON c.VendorID = u.VendorID WHERE u.Vendor_ID = @p_VendorID AND c.Approval_Status='NO'";
			
			var da1 = new SqlDataAdapter(sqlString, SqlCon);  
			da1.SelectCommand.Parameters.Add("@p_VendorID", SqlDbType.VarChar, 256);
			da1.SelectCommand.Parameters["@p_VendorID"].Value = txtHomeUsername.Text.Trim();
			
			var dt1 = new DataTable(); 
			da1.Fill(dt1); 
			if(da1.Rows.Any()){		
				string userId = string.Empty;
				string companyId = string.Empty;
				foreach(DataRow row in dt1.Rows){ 
					 userId = row["name"].ToString();
					 companyId = row["description"].ToString();
				 }
				 if(!string.IsNullOrEmpty(companyId)) {
				 	string url = "ApprovalStatus.aspx";     
					ClientScript.RegisterStartupScript(this.GetType(), "callfunction", "alert('Your Vendor ID is already registered');window.location.href = '" + url + "';", true);  
				 } else {
					Response.Redirect("RegPage1.aspx?Parameter=" + Server.UrlEncode (txtHomeUsername.Text));  
				 }			
			} else {
				ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('Enter valid VendorID or Password');", true);  				
			}
			  
		}
