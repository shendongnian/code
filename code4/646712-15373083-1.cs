    using (SqlCommand mycommand = new SqlCommand("SELECT * FROM datatable", conn))
    {
        try
        {
            conn.Open();
            mycommand.ExecuteNonQuery();
        }
        catch (SqlException ex)
        {
            label1.Visible = true;
            label1.Text = string.Format("Failed to Access Database! Please log into VPN Using The Link Below.\r\n\r\nError: {0}", ex.Message);
            return;
        }
            
        if (conn != null)
        {
            this.Hide();
            Form1 form = new Form1();
            form.Show();
        }
    }
