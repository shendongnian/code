    public static List<Image> GetAll(BOI caller) {
      List<Image> images = new List<Image>();
      using (SqlCeCommand cmd = new SqlCeCommand("SELECT * FROM Images", Connection.GetConnection(caller.ConnectionString))) {
        try {
          cmd.Connection.Open();
          using (SqlCeReader reader = cmd.ExecuteReader()) {
            while (reader.Read()) {
              object imageKey = reader["imageKey"];
              object filename = reader["filename"];
              object image = reader["image"];
              object labelKey = reader["labelKey"];
              object priority = reader["priority"];
              Image img = new Image((interface)imageKey, (string)filename, (byte[])image, (int?)labelKey, (int)priority);
              img.SetDBName(caller.ConnectionString);
              images.Add(img);
            }
          }
        } catch (SqlCeException err) {
          Console.WriteLine(err.Message);
          throw err;
        } finally {
          cmd.Connection.Close();
        }
      }
      return images;
    }
