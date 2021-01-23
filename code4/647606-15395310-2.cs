    protected void Button2_Click(object sender, EventArgs e)
    {
            	SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        	con.Open();
        	SqlCommand cmd = new SqlCommand("insert into tbl values('"+TxtUserName.Text+"','" + TxtPassword.Text+"','"+TxtRePassword.Text+"')", con);
        	cmd.ExecuteNonQuery();
        	con.Close();
        	TxtUserName.Text = "";
        	TxtPassword.Text = "";
        	TxtRePassword.Text = "";
