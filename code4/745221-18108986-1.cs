    public string GetFromResources(string resourceName)
    {
        Assembly assem = this.GetType().Assembly;
    
        using (Stream stream = assem.GetManifestResourceStream(resourceName))
        {
            using (var reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
    
        }
    }
