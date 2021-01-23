    using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["SQL Connection String"].ConnectionString)) {
        var sql = "Select * from TB_User where UserID=@UserID";
        using (var cmd = new SqlCommand(sql, con)) {
            cmd.Parameters.AddWithValue("@UserID", Label1.Text);
            con.Open();
            using(var reader = cmd.ExecuteReader())
            {
                while(reader.Read())
                {
                    // ...
                }
            }
        }
    }
    
