    if(MultiView1.ActiveViewIndex != 2)
    {
      using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["HSEProjRegConnectionString1"].ConnectionString))
      {
        conn.Open();
        using (SqlCommand cmd = new SqlCommand("SELECT [active] FROM [tbl_Person] WHERE username LIKE @username", conn))
        {
          cmd.Parameters.AddWithValue("@username", "%" + userName + "%");
          var res = cmd.ExecuteScalar();
          bool registeredAndActive = (bool)res;
          if (registeredAndActive)
          {
            // Active Condition. The DEFAULT in SWITCH() will take care of displaying content.
          }
          else
          {
            // !Active Condition.  Shows an alternative version of the default page where the user is told they do not have acces.
            Response.Redirect("default.aspx?Error_ID=2");
          }
        }
      }
    }
