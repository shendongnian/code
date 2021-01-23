        string MoneySaved = null;
        string sql = "Select Distinct(Tester) From VExecutionGlobalHistory Where Tester   = 'strUserName'";
        string connString = "myconnectionstringgoeshere";
        using (SqlConnection conn = new SqlConnection(connString))
        {
            conn.Open();
            using (SqlCommand command = new SqlCommand(sql, conn))
            {
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    MoneySaved = reader[0].ToString();
                    MoneySavedLabel.Text = MoneySaved;
                    //break for single row or you can continue if you have multiple     rows...
                    break;
                }
            }
            conn.Close();
        }
