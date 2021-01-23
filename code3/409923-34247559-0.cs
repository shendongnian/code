    public void InsertTableIntoDB_CreditLimitSimple(System.Data.DataTable tblFormat)
        {
            for (int i = 0; i < tblFormat.Rows.Count; i++)
            {
                String InsertQuery = string.Empty;
                InsertQuery = "INSERT INTO customercredit " +
                              "(ACCOUNT_CODE,NAME,CURRENCY,CREDIT_LIMIT) " +
                              "VALUES ('" + tblFormat.Rows[i]["AccountCode"].ToString() + "','" + tblFormat.Rows[i]["Name"].ToString() + "','" + tblFormat.Rows[i]["Currency"].ToString() + "','" + tblFormat.Rows[i]["CreditLimit"].ToString() + "')";
                using (MySqlConnection destinationConnection = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
                using (var dbcm = new MySqlCommand(InsertQuery, destinationConnection))
                {
                    destinationConnection.Open();
                    dbcm.ExecuteNonQuery();
                }
            }
        }//CreditLimit
