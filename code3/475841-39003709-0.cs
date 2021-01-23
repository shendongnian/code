    public static void CreateJsonFromCSV()
    {
        string path = "C:\\Users\\xx\\xx\\xx\\xx\\lang.csv";
        string textFilePath = path;
        const Int32 BufferSize = 128;
        using (var fileStream = File.OpenRead(textFilePath))
        using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize))
        {
            String line;
            Dictionary<string, string> jsonRow = new Dictionary<string, string>();
            while ((line = streamReader.ReadLine()) != null)
            {
                string[] parts = line.Split(',');
                string key_ = parts[0];
                string value = parts[1];
           
        
                if (!jsonRow.Keys.Contains(key_))
                {
                    jsonRow.Add(key_, value );
                }
    
            }
            var json = new JavaScriptSerializer().Serialize(jsonRow);
            string path_ = "C:\\XX\\XX\\XX\\XX\\XX.csv";
            File.WriteAllText(path_, json);
        }
 
    } 
