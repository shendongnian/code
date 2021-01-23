    private void listView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(listView1.SelectedItems.Count > 0)
        {
            SqlConnection cnn = new SqlConnection(tools.ConnectionString);
            SqlCommand cmd = new SqlCommand("select EmployeeId,BirthDate from Employees where FirstName = @name  ",cnn);
            cmd.Parameters.AddWithValue("@name", listView1.SelectedItems[0].Text );
            cnn.Open();
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            while (dr.Read())
            {
                MessageBox.Show("Id= "+dr["EmployeeID"].ToString() + "\nBirth Date= "+dr["BirthDate"].ToString());
            }
            cnn.Close();
        }
        
    }
