    List<User> lstUser = new List<User>();
                string sqlQuery = "Select * from User_T where User_Name='" + oUser.UserName + "' And Password='" +oUser.Password + "' AND IsActive='"+1+"' AND IsDelete='"+0+"'";
                string connectionString = "Data Source=ORCL;User Id=ACCOUNTS;Password=ACCOUNTS";
                using (DBManager dbManager = new DBManager(connectionString))
                {
                    try
                    {
    
                        dbManager.Open();
                        OracleDataReader dataReader = dbManager.ExecuteDataReader(sqlQuery);
                        while (dataReader.Read())
                        {
                            oUser = new User();
                            oUser.Id = Convert.ToInt32(dataReader["ID"]);
                            oUser.CompanyId = Convert.ToInt32(dataReader["Company_ID"]);
                            oUser.BranchId = Convert.ToInt32(dataReader["Branch_ID"]);
                            oUser.UserName = Convert.ToString(dataReader["User_Name"]);
                            lstUser.Add(oUser);
                        }
                        dataReader.Close();
                        dataReader.Dispose();
                       
                    }
                    catch
                    (Exception)
                    {
    
    
                    }
                    finally
                    {
                        dbManager.Close();
                        dbManager.Dispose();
                    }
