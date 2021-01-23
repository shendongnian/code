        String template = 
    @"EmpID\t\t{0}
    Name\t\t{1}
    Address\t\t{2}
    Birthday\t\t{3}";
        using (SqlConnection c = new SqlConnection( config.ConnectionString ))
        {
            c.Open();
            using (SqlCommand cmd = new SqlCommand("Select [EmpID], [Name], [Address], [Birthday] from EmpTable where EmpID = @EmpID", c))
            {
                cmd.Parameters.AddWithValue("@EmpID", textBox1.Text);
                using (SqlDataReader rdr = mySqlCommand.ExecuteReader())
                {
                    if (rdr.Read())
                    {
                        Int32  empId = rdr.GetInt32(rdr.GetOrdinal("EmpID")).ToString();                         
                        String name  = sqlreader.GetString(sqlreader.GetOrdinal("Name"));
                        String addr  = sqlreader.GetString(sqlreader.GetOrdinal("Address"));
                        String bday  = sqlreader.GetString(sqlreader.GetOrdinal("Birthday"));
                        
                        textbox.Text = String.Format(template, empId, name, addr, bday);
                    }//if
                }//using
            }//using
