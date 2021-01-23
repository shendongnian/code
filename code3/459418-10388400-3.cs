     public bool Login(String uName, String pasw)
    {
        using (SqlConnection myConnection = new SqlConnection(connString))
        {
            string oString = "Select ID from yourTable where username = @username AND paswoord = @password";
            SqlCommand oCmd = new SqlCommand(oString, myConnection);
            oCmd.Parameters.AddWithValue("@username", uName);
            oCmd.Parameters.AddWithValue("@password", pasw);
            string id = null;
            myConnection.Open();
            using (SqlDataReader oReader = oCmd.ExecuteReader())
            {              
                while (oReader.Read())
                {
                    id = oReader["id"].ToString();
                }
                myConnection.Close();
            }
            if (id == null)
            {
                return false;
            }
            else
            {
                return true;
            }         
        }
    }
