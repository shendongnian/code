    static void Main(string[] args)
    {
        ProcessWrite().Wait();
        Console.Write("Done ");
        Console.ReadKey();
    }
    
    static Task ProcessWrite()
    {
        string filePath = @"c:\temp2\temp2.txt";
        string text = "Hello World\r\n";
    
        return WriteTextAsync(filePath, text);
    }
    
    static async Task WriteTextAsync(string filePath, string text)
    {
        byte[] encodedText = Encoding.Unicode.GetBytes(text);
    
        using (FileStream sourceStream = new FileStream(filePath,
            FileMode.Append, FileAccess.Write, FileShare.None,
            bufferSize: 4096, useAsync: true))
        {
            await sourceStream.WriteAsync(encodedText, 0, encodedText.Length);
        };
    }
