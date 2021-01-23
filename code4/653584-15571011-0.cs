    string query = "SELECT * FROM EVERYTHING";
    using (var cmd = new SqlCeCommand(query, new SqlCeConnection(myConnStr)); {
      try {
        cmd.Connection.Open();
        using (var myReader = cmd.ExecuteReader()) {
          while (-1 < myReader.Peek()) {
           // Read Your Data
          }
        }
      } catch (SqlException err) {
        Console.WriteLine(err.Message); // <= Put a Break Point here.
      } finally {
        cmd.Connection.Close();
      } 
    }
