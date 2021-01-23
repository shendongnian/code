        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ToString());
        SqlCommand cmdUpdateKeyword = BuildCommand(conn, "proc_UpdateKeyword");
        cmdUpdateKeyword.Parameters.AddWithValue("@Keyword", strKeyword);
        conn.Open();
        int i = Convert.ToInt32(cmdUpdateKeyword.ExecuteScalar());
        conn.Close();
        BindGrid();
    }
