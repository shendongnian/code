    private static void SaveToDb(string xml)
    {
        using (var connection = new SqlConnection(conn))
        using (var command = new SqlCommand(
            "INSERT MyXmlTable VALUES (@XML)",
            connection))
        {
            command.Parameters.Add("XML", SqlDbType.Xml, xml.Length).Value = xml;
            connection.Open();
            var result = command.ExecuteNonQuery();
        }
    }
