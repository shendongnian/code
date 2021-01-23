    string connectionstring = "Server=Momal-PC\\MOMAL;Database=Project;Trusted_Connection=True;";
    SqlConnection conn = new SqlConnection();
    conn.ConnectionString = connectionstring;
    conn.Open();
    string sql = "UPDATE Members SET Type = '@Type' , FirstName = '@FirstName', Address = '@Address' , [D.O.B] = '@[D.O.B]' Where Number  = '" + comboBox1.Text + "'";
     SqlCommand cmd = conn.CreateCommand();
     cmd.CommandType = CommandType.Text;
     cmd.CommandText = sql;
     cmd.Parameters.Add(new SqlParameter("@Type", comboBox1.Text));
     cmd.Parameters.Add(new SqlParameter("@FirstName", FNTxt.Text));
     cmd.Parameters.Add(new SqlParameter("@Address", ATxt.Text));
     cmd.Parameters.Add(new SqlParameter("@[D.O.B]", dateTimePicker1.Value));
     int rowsInserted = cmd.ExecuteNonQuery();
     MessageBox.Show("Done!");
    conn.Close()
