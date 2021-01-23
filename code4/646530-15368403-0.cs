    var cn = new SqlConnection("some connection string");
    var cmd = new SqlCommand("SELECT ID FROM SomeTable", cn);
    var reader = cmd.ExecuteReader();
    while (reader.Read())
    {
        var id = reader.GetInt32(0);
        // an so on
    }
    reader.Close();
    reader.Dispose();
    cn.Close();
