    public async Task ProcessFiles()
    {
        List<string> fileNames = await LoadList();
        // Now process the files
    }
    public async Task<List<string>> LoadList()
    {
        List<string> fileNames = new List<string>();
        // Do stuff...
        return fileNames;
    }
