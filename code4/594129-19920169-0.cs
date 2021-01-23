    using (SqlConnection stockConn = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString))
    {
            // Check for trade match offer
            SqlCommand tradePCCheck = new SqlCommand("getAllMyPriceMatches", stockConn);
            tradePCCheck.CommandType = CommandType.StoredProcedure;
            SqlParameter email = tradePCCheck.Parameters.Add("@email", SqlDbType.NVarChar);
            try
            {
                email.Value = this.Context.User.Identity.Name;
            }
            catch
            {
                email.Value = " ";
            }
            SqlParameter thedate = tradePCCheck.Parameters.Add("@theDate", SqlDbType.DateTime);
            thedate.Value = DateTime.Now.AddHours(-50);
    
            stockConn.Open();
        
        SqlDataReader pcReader = tradePCCheck.ExecuteReader();
           
        decimal px = 0;
        decimal cash = 0;
    
    	if (pcReader.Read())
        {
            px = pcReader.GetDecimal(0);
            cash = pcReader.GetDecimal(1);
        }
        pcReader.Close();
        stockConn.Close();
    }
