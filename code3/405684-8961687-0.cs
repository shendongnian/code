    static string PeekStream(ref Stream stream)
    {
        string content;
        var reader = new StreamReader(stream);
        content = reader.ReadToEnd();
        if (stream.CanSeek)
        {
            stream.Seek(0, SeekOrigin.Begin);
        }
        else
        {
            stream.Dispose();
            stream = new MemoryStream(Encoding.UTF8.GetBytes(content));
        }
        return content;
    }
