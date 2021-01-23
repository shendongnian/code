    { 
    	string url = string.empty;
    	
    	using (SqlConnection dbconn = new SqlConnection(Application["dbconn"].ToString())) {
        	using (SqlCommand sqlValidate = dbconn.CreateCommand()) {
    		    dbconn.Open();
    		    sqlValidate.CommandText = "SELECT lastName, csn FROM Demographics WHERE lastName = '" + Session["lastName"].ToString() + "' " +
    		        "AND dob = '" + Session["dobCheck"].ToString() + "' AND mrn = " + strMRN;
    		    using (SqlDataReader results = sqlValidate.ExecuteReader()) {
    		    	if (results.HasRows) {
    					string csn = "";
    		    	    while (results.Read())
    		        	{
    		            	if (!String.IsNullOrEmpty(results["csn"].ToString()))
    		            	{
    		                	csn = results["csn"].ToString();
    		                	break;
    		            	}
    		        	}
    		        	url = Application["surveyUrlString"] + "&lastname=" + Session["lastName"].ToString() + "&mrn=" + strMRN + "&dobday=" + Session["dobday"].ToString() 
    		                    + "&dobmonth=" + Session["dobmonth"].ToString() + "&dobyear=" + Session["dobyear"].ToString() + "&csn=" + csn;
    	            }
    			} // sqldatareader
        	} // using sqlcommand
    	} // using sqlconnection
    	if (!String.IsNullOrEmpty(url)) {
    		Response.Redirect(url, false);
    	}
    }
