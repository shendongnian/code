    public string GetContent(string path)
    {
        Contract.Requires<FileMissingException>(File.Exists(path));
        Contract.Ensures(!String.IsNullOrEmpty(Contract.Result<string>()));
        
        using(var reader = new StreamReader(File.OpenRead(path)))
        {
            var content = reader.ReadToEnd();
            
            if(String.IsNullOrEmpty(content))
                throw new FileContentException("No content found at file: " + path);
            
            return content;
        }
    }
