        using(SqlConnection con = new SqlConnection(conn))
        using(SqlCommand cmd = new SqlCommand("my_SP", con))
        {
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Name", ""));
            cmd.Parameters.Add(new SqlParameter("@Course", ""));
            foreach (string item in attend)
            {
                cmd.Parameters["@Name"].Value = item;
                cmd.Parameters["@Course"].Value  = attender.SelectedValue);
                cmd.ExecuteNonQuery();
            }
         }
