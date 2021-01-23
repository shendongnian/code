		using(SqlConnection SqlCon = new SqlConnection(GetConnectionString()) {
			var sqlString = "SELECT 1 FROM User_Info u INNER JOIN Company_Info c ON c.VendorID = u.VendorID WHERE u.Vendor_ID = @p_VendorID AND c.Approval_Status='NO'";
			var da1 = new SqlDataAdapter(sqlString, SqlCon);  			
			da1.SelectCommand.Parameters.Add("@p_VendorID", SqlDbType.VarChar, 256);
			da1.SelectCommand.Parameters["@p_VendorID"].Value = txtHomeUsername.Text.Trim();
			da1.Fill(dt1); 
			if(da1.Rows.Any()){			
			   string url = "ApprovalStatus.aspx";     
			   ClientScript.RegisterStartupScript(this.GetType(), "callfunction", "alert('Your Vendor ID is already registered');window.location.href = '" + url + "';", true);  			
			} else {
				Response.Redirect("RegPage1.aspx?Parameter=" + Server.UrlEncode (txtHomeUsername.Text));  
			}
			ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('Enter valid  VendorID or Password');", true);    
		}
