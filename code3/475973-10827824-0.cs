    public async Task ProcessFileAsync(string filename)
    {
        var lines = await ReadLinesFromFileAsync(filename);
        var parsed = await ParseLinesAsync(lines);
        await UpdateDatabaseAsync(parsed);
    }
