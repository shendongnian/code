      Dictionary<int, List<Decimal>> result = new Dictionary<int, List<Decimal>>();
    
      using (var reader = cmd.ExecuteReader()) {
        while (reader.Read()) {
          int id = int.Parse(reader["ID"].ToString());
          Decimal price = Decimal.Parse(reader["PRICE"].ToString());
          List<Decimal> list;
    
          if (result.TryGetValue(id, out list))    
            list.Add(price);
          else 
            result.Add(id, new List<Decimal> {price});
        }
      }
