    protected void submit(object sender, EventArgs e)
    
        using (SqlCommand scom = new SqlCommand("spx_Send_Status_Mail", new SqlConnection(ConfigurationManager.ConnectionStrings["EPOCHSConnectionString"].ConnectionString))) {
    
            scom.CommandType =CommandType.StoredProcedure;    
            SqlParameter EmailTo = new SqlParameter("@EmailTo", SqlDbType.NVarChar, 200);
            EmailTo.Direction = ParameterDirection.Output;
            scom.Parameters.Add(EmailTo);    
            SqlParameter EmailFrom = new SqlParameter("@EmailFrom", SqlDbType.NVarChar, 200);
            EmailFrom.Direction = ParameterDirection.Output;
            scom.Parameters.Add(EmailFrom);
    
            try {
                scom.Connection.Open();
                scom.ExecuteNonQuery();
                scom.ExecuteReader(CommandBehavior.CloseConnection);
            } finally {
                scom.Connection.Close();
            }
            mail message = new mail();
    
            //Get output parameters after executing query
            string to = EmailTo.Value.ToString();
            string from = EmailFrom.Value.ToString();
            //Pass To and From email addresses to the ESendmail function
            mailsystem.Esendmail(to,from);
        }
    }
