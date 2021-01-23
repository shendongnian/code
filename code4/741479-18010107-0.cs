           {
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            string query = "select project_name from JO.dbo.Proj left join JO.dbo.Comp on Proj.company_id = Comp.company_id where company_name = '" + comboBox1.SelectedItem + "'";
            SqlCommand command = new SqlCommand(query, conn);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                comboBox2.Items.Clear();
                while (reader.Read())
                {
                    comboBox2.Items.Add(reader["project_name"].ToString());
                }
                reader.Close();
            }
            conn.Close();
            conn.Dispose();
        }
