    var sql = "SELECT UniqueString, ID  FROM Table";
    var rows = new List<Dictionary<string, int>>();
    using (var reader = cn.ExecuteReader(sql)) {
        while (reader.Read()) {
            var dict = new Dictionary<string, int>();
            for (var i = 0; i < reader.FieldCount; i++) {
                dict[reader.GetName(i)] = reader.GetInt32(i);
            }
            rows.Add(dict);
        }
    }
