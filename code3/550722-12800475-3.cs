    public static T LoadFromFile<T>(string fileName)
    {
        using (StreamReader reader = new StreamReader(FileName))
        {
           return JsonConvert.DeserializeObject<T>(WpfApplication.Helper.Decrypt(reader.ReadToEnd()));
        }
    }
