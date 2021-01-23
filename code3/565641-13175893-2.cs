      public string GetUserID(string EmailAdd, string Password)
        {
            SqlConnection myConnection = new SqlConnection(@"user id=BankUser;password=Computer1;server=(local)\sql2008;database=BillionBank;");
            myConnection.Open();
            SqlCommand myCommand = new SqlCommand("SELECT * FROM [BillionBank].[dbo].[tblCustomerProfile] WHERE EmailAdd='" + EmailAdd + "' AND Password ='" + Password + "'", myConnection);
            SqlDataReader myreader;
            string result = "";
            myreader = myCommand.ExecuteReader();
            if (myreader.Read())
            {
                result = Convert.ToString(myreader["UserID"]);
            }
            return result;
        }
    Session["UserID"] = GetUserID();
