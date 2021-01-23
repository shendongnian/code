    using(SqlConnection con = new SqlConnection("Data Source=HRC0;Initial Catalog=users;Integrated Security=True"))
    using(SqlCommand sc = new SqlCommand("if NOT exists (select * from users where UserName = @username) insert into users (userName, password) values(@userName, @password)",con))
    {
        sc.Parameters.AddWithValue("@username", korisnik.Text);
        sc.Parameters.AddWithValue("@password", pass.Text);
        int o = sc.ExecuteNonQuery();
        con.Open();
    }
