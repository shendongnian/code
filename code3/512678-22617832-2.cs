    static void Main(string[] args)
    {
        ProcessRead().Wait();
        Console.Write("Done ");
        Console.ReadKey();
    }
    
    static async Task ProcessRead()
    {
        string filePath = @"c:\temp2\temp2.txt";
    
        if (File.Exists(filePath) == false)
        {
            Console.WriteLine("file not found: " + filePath);
        }
        else {
            try {
                string text = await ReadTextAsync(filePath);
                Console.WriteLine(text);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
    
    static async Task<string> ReadTextAsync(string filePath)
    {
        using (FileStream sourceStream = new FileStream(filePath,
            FileMode.Open, FileAccess.Read, FileShare.Read,
            bufferSize: 4096, useAsync: true))
        {
            StringBuilder sb = new StringBuilder();
    
            byte[] buffer = new byte[0x1000];
            int numRead;
            while ((numRead = await sourceStream.ReadAsync(buffer, 0, buffer.Length)) != 0)
            {
                string text = Encoding.Unicode.GetString(buffer, 0, numRead);
                sb.Append(text);
            }
    
            return sb.ToString();
        }
    } 
