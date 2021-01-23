    string SQLconnection = WebConfigurationManager.ConnectionStrings["DatabaseConnectionString"].ConnectionString;
        string[] field;
        field = new string[6];
        field[0] = "Nothing to search"; // add here in case string is null
        if (!string.IsNullOrEmpty(code))
        {
            string SQLSelect = "SELECT user_name, user_surname, user_code, user_group, user_password FROM Users WHERE user_code=@user_code";
            SqlConnection connect = new SqlConnection(SQLconnection);
            SqlCommand search = new SqlCommand(SQLSelect, connect);
            search.Parameters.Clear();
            search.Parameters.AddWithValue("@user_code", code);
            try
            {                    
                connect.Open();
                SqlDataReader info = search.ExecuteReader();
                if (info.HasRows)
                {
                    field[0] = "Data loaded";
                }
            }
            catch
            { 
                // error handle here problem with connection
            }
            finally 
            {
                connect.Close();
            }
        }
        return field;
