    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection"].ConnectionString);
    		
    		SqlCommand deleteCmd = new SqlCommand("DELETE FROM ExpTab WHERE username = @name AND month = @mnth", conn);
    		deleteCmd.CommandType = CommandType.Text;
            deleteCmd.Parameters.AddWithValue("@name", Membership.GetUser().UserName);
            deleteCmd.Parameters.AddWithValue("@mnth", Label1.Text);
    		deleteCmd.ExecuteNonQuery();
    		
        SqlCommand cmd = new SqlCommand("Insert into ExpTab (username,month,ex1,p1) Values (@name,@mnth,@ex1s,@p1s)", conn);
    
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.AddWithValue("@name", Membership.GetUser().UserName);
        cmd.Parameters.AddWithValue("@mnth", Label1.Text);
        .
        .
        .
        .
