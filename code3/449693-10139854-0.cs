    public String ToXml()
    {
        var objSerializer =
            new DataContractSerializer(GetType());
        
        using (var objStream = new MemoryStream())
        {
            //  Serialize the object
            objSerializer.WriteObject(objStream, this);
            // Move to start of stream to read 
            // out contents
            objStream.Seek(0, SeekOrigin.Begin);
            using (var objReader =
                new StreamReader(objStream))
            {
                // Read Contents into a string
                retirm objReader.ReadToEnd();
            }
        }
    }
