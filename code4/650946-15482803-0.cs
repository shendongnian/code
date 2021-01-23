        string connectionString = "Server = HP-PC\\SQLExpress; Database = CProject; Trusted_Connection = True";
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            string sql = "delete from [Login] where UserName = @UserName;";
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                SqlParameter p = new SqlParameter("UserName", comboBox1.SelectedText.ToString());
                cmd.Parameters.Add(p);
                cmd.ExecuteNonQuery();
            }
        }
