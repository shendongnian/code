    using(var c = new SqlConnection(provider))
    {
     c.Open();
     using(var sc = c.CreateCommand())
     {
      sc.CommandText = "INSERT "+table+" VALUES(@data)";
      sc.Parameters.AddWithValue("@data", src.ToArray());
      sc.ExecuteNonQuery();
     }
    }
