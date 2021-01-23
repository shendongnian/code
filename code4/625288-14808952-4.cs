    string st = TextBox1.Text;
    wservices.whois myservices = new wservices.whois();
    string textData = myservices.GetWhoIS(st);
    TextBox2.Text = textData;
    using(SqlConnection conn = new SqlConnection(connectionString));
    {
      SqlCommand cmd = new SqlCommand("INSERT INTO WhoIsData(WhoIsData) VALUES(@text);");
      cmd.Connection = conn;
      cmd.Parameters.AddWithValue("@text", textData);
      conn.Open();
      cmd.ExecuteNonQuery();
    }
