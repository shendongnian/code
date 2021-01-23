    string query = "SELECT * FROM EVERYTHING";
    var table = new DataTable();
    using (var cmd = new SqlCeCommand(query, new SqlCeConnection(myConnStr)); {
      try {
        cmd.Connection.Open();
        table.Load(cmd.ExecuteReader());
      } catch (SqlException err) {
        Console.WriteLine(err.Message); // <= Put a Break Point here.
      } finally {
        cmd.Connection.Close();
      } 
    }
    object col1 = null;
    string strCol2 = null;
    if (0 < table.Rows.Count) {
      col1 = table.Rows[0][0];
      object obj = table.Rows[0][1];
      if ((obj != null) && (obj != DBNull.Value)) {
        strCol2 = obj.ToString();
      }
    }
