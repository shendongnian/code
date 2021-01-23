        string var_Select = "SELECT fld_logUserName,fld_logPassword FROM tbl_SystemAccess where fld_logUserName = '" + var_words[1].Trim() +
                                    "' AND " + "fld_logPassword = '" + var_words[2].Trim() + "' AND fld_logIPAddress = '" + var_words[3].Trim() + "'";
       //test boolean result from mySQLQuery_exist
        if (mySQLQuery_exist(var_Select))
        {
        ....
        ....
        // function to check if any records found or none
        public Boolean mySQLQuery_exist(string var_SQLCommand)
        {
            Boolean var_Result = false;
            using (SqlConnection myConn = new SqlConnection(var_pubicSQLConnect))
            using (SqlCommand var_command = new SqlCommand(var_SQLCommand, myConn))
            {
                myConn.Open();
                using (SqlDataReader var_RS = var_command.ExecuteReader())
                    if (var_RS.Read())
                        var_Result = true;
            }
            return var_Result;            
        }
