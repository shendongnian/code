     string statusReturned = "";
     int workflowID = Convert.ToInt32(statusCode.SelectedValue);
     
     using (SqlConnection sqlConnection2 = new SqlConnection(sqlDevelopment.ConnectionString))
        {
    		string status = "select status from jm_accountworkflowdetail where workid = @workID";
            SqlCommand sqlComm2 = new SqlCommand(status, sqlConnection2);
            sqlComm2.Parameters.AddWithValue("@workID", workflowID);
            try
            {
                sqlConnection2.Open();
                var returnValue = sqlComm2.ExecuteScalar()
    				if returnValue != null then
    				  statusReturned = returnValue.ToString();
            }
            catch (Exception ex)
            {
                //handle exception
            }
        }
        return statusReturned;
