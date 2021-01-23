    protected void Button1_Click(object sender, EventArgs e)
    {
        using(SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings    ["Connection"].ConnectionString))
        {
          conn.Open(); //you were missing this
          SqlCommand cmd = new SqlCommand("SELECT * FROM ExpTab WHERE UserID = @UserName and month(date_column)=@month",  conn);
          cmd.Parameters.Add(new SqlParameter("UserName", 
          HttpContext.Current.User.Identity.Name));
          cmd.Parameters.Add(new SqlParameter("@month", dropDownDate.SelectedValue));
        }
    }
