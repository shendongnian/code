    SqlConnection dataConnection = new SqlConnection();
                try
                {
                    SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                    builder.DataSource = "UNKNOWN01-PC\\SQLEXRESS2008R2";
                    builder.InitialCatalog = "Northwind";
                    //builder.IntegratedSecurity = true;
                    builder.UserID = "testlogin";
                    builder.Password = "1234";
                    dataConnection.ConnectionString = builder.ConnectionString;
                    dataConnection.Open();
                }
                catch  (Exception)
                {
                    throw;
                }
