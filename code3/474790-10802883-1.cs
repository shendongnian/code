    private static async Task WriteToFile(string s)
    {
        using (var writer = new StreamWriter(GetFileName()))
            await writer.WriteAsync(s);
    }
