    string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
    
    using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["HSEProjRegConnectionString1"].ConnectionString))
    {
        conn.Open();
        using (SqlCommand cmd = new SqlCommand("SELECT [active] FROM [tbl_Person] WHERE username = @username", conn))
        {
            // since we can literally filter the results, if something comes back
            // we know they are registered
            cmd.Parameters.AddWithValue("@username", userName);
            var res = cmd.ExecuteScalar();
            bool registeredAndActive = (bool)res;
            // unless of course `[active]` is an INT -then do this
            bool registeredAndActive = (int)res == 1 ? true : false;
            // but really -set [active] up as a BIT if it's not **and**
            // please make it non-nullable :D
        }
    }
