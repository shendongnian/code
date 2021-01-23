    string query;
    string str = "Data Source=blank blank blank;Initial Catalog=test;User ID=hello;Password=password";
    SqlConnection con = new SqlConnection(str);
    con.Open();
    query = "INSERT INTO table dbo.url_map Values (@Url)";
    SqlCommand cmd = new SqlCommand(query, con);
    cmd.Parameters.AddWithValue("@Url", tbLongURL.Text);
    cmd.ExecuteNonQuery();
    con.Close(); 
