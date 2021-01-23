    using (SqlConnection UGIcon = new SqlConnection("Data Source=localhost\\sqlexpress;Initial Catalog=UGI;Integrated Security=True"))
            {
                UGIcon.Open();
                string userText = textBox11.Text;
                string passText = textBox12.Text;
                SqlCommand cmd = new SqlCommand("SELECT stUsername,stPassword, stRole FROM LoginDetails WHERE stUsername='" + userText + "' and stPassword='" + passText + "'", UGIcon);
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {
                            string role = rdr["stRole"].ToString();
                            MessageBox.Show(role);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Access Denied!!");
                    }
                }
            }  
