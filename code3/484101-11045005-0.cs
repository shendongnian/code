     SqlCommand command = new SqlCommand("inserting", con);
     command.CommandType = CommandType.StoredProcedure;
     command.Parameters.Add("@Firstname", SqlDbType.NVarChar, 100).Value = TextBox1.Text;
     command.Parameters.Add("@Lastname", SqlDbType.NVarChar, 100).Value = TextBox2.Text;
     command.Parameters.Add("@City", SqlDbType.NVarChar, 100).Value = TextBox3.Text;
     command.Parameters.Add("@ID", SqlDbType.Int).Value = Convert.ToInt32(TextBox4.Text);
     ....... and so on .....
