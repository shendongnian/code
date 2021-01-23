    public async Task<string> ProcessRequest()
    {
        using (var textFile = File.OpenText("file.txt"))
        {
            var s = await textFile.ReadToEndAsync();
            return s;
        }
    }
