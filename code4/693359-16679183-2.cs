    using(SqlCeConnection conn = new SqlCeConnection(@"Data Source|DataDirectory|\MyData.sdf;Persist Security Info=False;"))
    using(SqlCeCommand cmd1 = new SqlCeCommand("SELECT Admin FROM SystemUsers WHERE Email=@mail", conn))
    {
        conn.Open();
        cmd1.Parameters.AddWithValue("@mail", user.Email);
        SqlCeDataReader admin = cmd1.ExecuteReader();
        while(admin.Read())
        {
          .....
        }
    }
