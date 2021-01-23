    string sql = "";
    using (StreamReader reader = new StreamReader(Assembly.GetExecutingAssembly().
           GetManifestResourceStream("<AssemblyName>.<NameOfTextFile>")) {
        sql = reader.ReadToEnd();
    }
    if (!string.IsNullOrEmpty(sql))
    {
        using (var conn = new SqlConnection("<connection string>")) {
            using (var cmd = new SqlCommand(sql)) {
                cmd.CommandType = CommandType.Text;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    // Use the reader to read data
                }
            }
        }
    }
       
    
