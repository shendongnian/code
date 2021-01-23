    private static Stream ConvertToStream(string fileUrl)
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(fileUrl);
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        
        try {
            MemoryStream mem = new MemoryStream();
            Stream stream = response.GetResponseStream();
            stream.CopyTo(mem,4096);
    
            return mem;
        } finally {
            response.Close();
        }
    }
