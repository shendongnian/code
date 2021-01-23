    private static void ConvertToStream(string fileUrl, Stream stream)
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(fileUrl);
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        
        try {
            stream.CopyFrom(response.GetResponseStream(),4096);
        } finally {
            response.Close();
        }
    }
