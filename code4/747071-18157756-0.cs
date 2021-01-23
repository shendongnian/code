    [WebMethod]
    public string UploadXml(string xmlString) {
      using (var connection = new SqlConnection(myConnectionString)) {
        using (var command = connection.CreateCommand()) {
          command.CommandText = "INSERT INTO MyTable (xmlColumn) VALUES (@xmlText)";
          command.Parameters.AddWithValue("@xmlText", xmlString);
          // etc.
        }
      }
    }
