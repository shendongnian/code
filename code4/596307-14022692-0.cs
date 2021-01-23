     private async static void WriteFileTextAsync(string text, Stream stream)
    {
        for (int i = 0; i < 100; i++)
        {
            var fileText = string.Format("{0} in process {1}\n", text, i);
            byte[] textBytes = Encoding.UTF8.GetBytes(fileText);
            stream.SetLength(stream.Length + textBytes.Length);
            await stream.WriteAsync(textBytes, 0, textBytes.Length);
            new System.Threading.ManualResetEvent(false).WaitOne(100);
        }
    }
