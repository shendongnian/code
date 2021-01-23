    List<int> items=new List<int>();
    using (IDataReader reader = db.ExecuteReader(dbCommand))
    {
          while (reader.Read())
          {
             items.Add(reader.GetInt32(reader.GetOrdinal("YourColumnName"));
          }
    }
