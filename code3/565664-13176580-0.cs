    private static Stream ConvertToStream(string fileUrl)
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(fileUrl);
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        
        try {
            MemoryStream mem = new MemoryStream();
    
            mem.CopyFrom(reponse.GetResponseStream(),4096);
    
            return mem;
        } finally {
            response.Close();
        }
    }
