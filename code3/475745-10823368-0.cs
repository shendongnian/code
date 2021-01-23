        static void Main(string[] args)
        {
            var doc = new XmlDocument();
            var fileName = @"C:\test.xml";
            doc.Load(fileName);
            var connection = new SqlConnection(@"Data Source=MyServer; 
                 Initial Catalog=MyDatabase; Integrated Security=SSPI");
            connection.Open();
            var command = new SqlCommand(
                 "INSERT INTO dbo.Shapes (shape, desc) VALUES (@a, @b)", connection);
            command.CommandType = CommandType.Text;
            command.Parameters.Add("@a", SqlDbType.Xml);
            command.Parameters["@a"].Value = doc.OuterXml;
            command.Parameters.Add("@b", SqlDbType.VarChar);
            command.Parameters["@b"].Value = doc.InnerXml;
            command.ExecuteNonQuery();
            connection.Close();
        }
