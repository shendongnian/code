    using(var con = new SqlConnection(ConnectionString))
    using(var sc = new SqlCommand("if NOT exists (select * from users where UserName = @username) insert into users (userName, password) values(@userName, @password)",con))
    {
        sc.Parameters.AddWithValue("@username", korisnik.Text);
        sc.Parameters.AddWithValue("@password", pass.Text);
        con.Open();
        int o = sc.ExecuteNonQuery();
    }
