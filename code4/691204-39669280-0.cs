    SqlConnection con = new SqlConnection("connection_string");
    SqlCommand cmd = new SqlCommand("select Count(*) from [dbo].[Table] where uname=@uname and password=@password");
    cmd.Connection = con;
    con.Open();
    cmd.Parameters.AddWithValue("@uname", uname.Text);
    cmd.Parameters.AddWithValue("@password", password.Text);
    int Result=(int)cmd.ExecuteScalar();
    if (Result > 0)
     {
    Response.Redirect("welcome.aspx");
    }
     else
    {
    Response.Redirect("register.aspx");
     }
