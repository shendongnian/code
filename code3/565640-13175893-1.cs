     public string GetUserID()
        
        {       
                 SqlConnection myConnection = new SqlConnection(@"user id=BankUser;password=Computer1;server=(local)\sql2008;database=BillionBank;");
                 myConnection.Open();
                 SqlCommand myCommand = new SqlCommand("SELECT * FROM [BillionBank].[dbo].[tblCustomerProfile] WHERE EmailAdd='" + EmailAdd + "' AND Password ='" + Password + "'", myConnection);
                 SqlDataReader myreader;
                 myreader = myCommand.ExecuteReader();
                 if (myreader.Read())
                    {
                        return Convert.ToString(myreader["UserID"]);
                    }
                    
                }
    Session["UserID"] = GetUserID();
