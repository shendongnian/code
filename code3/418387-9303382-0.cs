            using (SqlConnection SQL_Conn01 = new SqlConnection(SQLSync))
            {
                bool IsConnected = false;
                try
                {
                    SQL_Conn01.Open();
                    IsConnected = true;
                }
                catch
                {
                    // unable to connect
                }
                if (IsConnected)
                {
                    SqlCommand GetSQL = new SqlCommand("SELECT email_address FROM account_info", SQL_Conn01);
                    using (SqlDataReader Reader = GetSQL.ExecuteReader())
                    {
                        while (Reader.Read())
                        {
                            string EmailAddress = Reader.GetString(0).TrimEnd();
                        }
                    }
                    GetSQL.Dispose();
                }
            }
