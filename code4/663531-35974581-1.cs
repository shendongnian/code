        private void restoreButton_Click(object sender, EventArgs e)
        {
        string database = con.Database.ToString();
        if (con.State != ConnectionState.Open)
        {
            con.Open();
        }
        try
        {
            string sqlStmt2 = string.Format("ALTER DATABASE [" + database + "] SET SINGLE_USER WITH ROLLBACK IMMEDIATE");
            SqlCommand bu2 = new SqlCommand(sqlStmt2, con);
            bu2.ExecuteNonQuery();
    
            string sqlStmt3 = "USE MASTER RESTORE DATABASE [" + database + "] FROM DISK='" + textBox2.Text + "'WITH REPLACE;";
            SqlCommand bu3 = new SqlCommand(sqlStmt3, con);
            bu3.ExecuteNonQuery();
    
            string sqlStmt4 = string.Format("ALTER DATABASE [" + database + "] SET MULTI_USER");
            SqlCommand bu4 = new SqlCommand(sqlStmt4, con);
            bu4.ExecuteNonQuery();
    
            MessageBox.Show("database restoration done successefully");
            con.Close();
    
       }
       catch (Exception ex)
       {
            MessageBox.Show(ex.ToString());
       }
    }
