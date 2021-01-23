    private string ExtractJsonResponse(WebResponse response)
    {
        string json;
        using (var outStream = new MemoryStream())
        using (var zipStream = new GZipStream(response.GetResponseStream(),
            CompressionMode.Decompress))
       {
            zipStream.CopyTo(outStream);
            outStream.Seek(0, SeekOrigin.Begin);
            using (var reader = new StreamReader(outStream, Encoding.UTF8))
            {
                json = reader.ReadToEnd();
           }
        }
        return json;
    }
