    Id INT PRIMARY KEY IDENTITY(1,1),
    WhoIsFile NVARCHAR(256)
)
    string st = TextBox1.Text;
    wservices.whois myservices = new wservices.whois();
    string textData = myservices.GetWhoIS(st);
    TextBox2.Text = textData;
    string fileName = Guid.NewGuid().ToString();
    using(var file = File.OpenWrite(fileName))
    {
        file.Write(textData);
    }
    using(SqlConnection conn = new SqlConnection(connectionString));
    {
      SqlCommand cmd = new SqlCommand("INSERT INTO WhoIsData(WhoIsFile) VALUES(@fileName);");
      cmd.Connection = conn;
      cmd.Parameters.AddWithValue("@fileName", fileName);
      conn.Open();
      cmd.ExecuteNonQuery();
    }
