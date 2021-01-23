     private async static Task GetFileTextAsync(string text, Stream stream)
    {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < 100; i++)
        {
            sb.AppendLine(string.Format("{0} in process {1}\n", text, i));            
        }
        await stream.WriteAsync(textBytes, 0, textBytes.Length);
    }
