    private void getAgentInfo(string key)//"key" is your search paramter inside database
        {
            con.Open();
            string sqlquery = "SELECT * FROM TableName WHERE firstname = @fName";
            SqlCommand command = new SqlCommand(sqlquery, con); 
            SqlDataReader sReader;
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@fName", key);
            sReader = command.ExecuteReader();
            while (sReader.Read())
            {
                textBoxLastName.Text = oReader["Lastname"].ToString(); 
                //["LastName"] the name of your column you want to retrieve from DB
                textBoxAge.Text = oReader["age"].ToString();
                //["age"] another column you want to retrieve
            }
            con.Close();
        }
