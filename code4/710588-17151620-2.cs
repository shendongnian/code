    private void buttonUpdateProfileClass_Click(object sender, EventArgs e) 
    {
        int ID = Convert.ToInt32(recordID.Text);
        int oldPC = Convert.ToInt32(oldProfileClass.Text);
        int NewPC = Convert.ToInt32(newProfileClass.Text);
        string connstr = @"Initial Catalog=myDB;Data Source=localhost;Integrated Security=SSPI;";
        SqlConnection conn = new SqlConnection(connstr);
        conn.Open();
        var cmd= new SqlCommand("dbo.updateclass", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ID", ID);
        cmd.Parameters.AddWithValue("@NEWCLASS", NewPC);
        cmd.Parameters.AddWithValue("@OLDCLASS", oldPC); 
        cmd.ExecuteNonQuery();
        cmd.Dispose();
        conn.Close();
        conn.Dispose();
        MessageBox.Show("Profile Class updated");
    }
