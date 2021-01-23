    const string text = "\"one,\",2,3,\"four\",\"five\"";
    
    using (var textReader = new StringReader(text))
    using (var reader = new CsvReader(textReader))
    {
        reader.Configuration.Delimiter = ',';
        reader.Configuration.AllowComments = false;
        reader.Configuration.HasHeaderRecord = false;
    
        if (reader.Read())
        {
            foreach (var item in reader.CurrentRecord)
            {
                Console.WriteLine(item);
            }
        }
    }
