            // read previously chosen items from database
            string sql = "SELECT * FROM tblSelectedHobbies WHERE iPersonID=@pPersonID";
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = myConnStr;
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("pPersonID", id); // id from query string, or wherever
            SqlDataReader reader = cmd.ExecuteReader();
            // iterate through saved entries and add to Hashtable
            Hashtable savedEntries = new Hashtable();
            while (reader.Read())
            {
                string hobbyID= reader["iHobbyID"].ToString();
                savedEntries[hobbyID] = true;
            }
            conn.Close();
            // check the corresponding boxes
            dsHobbies.DataBind();
            cblHobbies.DataBind();
            foreach (ListItem li in cblHobbies.Items)
            {
                if (savedEntries.ContainsKey(li.Value))
                {
                    li.Selected = true;
                }
            }
