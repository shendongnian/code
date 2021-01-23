    private static void ConvertToStream(string fileUrl, Stream stream)
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(fileUrl);
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        
        try {
            Stream response_stream = response.GetResponseStream();
            response_stream.CopyTo(stream,4096);
        } finally {
            response.Close();
        }
    }
