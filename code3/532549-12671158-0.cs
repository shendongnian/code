    public void CreateFolder(string url)
        {
            HttpWebRequest request = (System.Net.HttpWebRequest)HttpWebRequest.Create(url);
            request.Credentials = new NetworkCredential(user, pass);
            request.Method = "MKCOL";
            HttpWebResponse response = (System.Net.HttpWebResponse)request.GetResponse();
            response.Close();
        }
    public void UploadDocument(byte[] file, string destinationName)
        {
            byte[] buffer = file;
            WebRequest request = WebRequest.Create(destinationName);
            request.Credentials = new System.Net.NetworkCredential(user, pass);
            request.Method = "PUT";
            request.ContentLength = buffer.Length;
            BinaryWriter writer = new BinaryWriter(request.GetRequestStream());
            writer.Write(buffer, 0, buffer.Length);
            writer.Close();
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            response.Close();
        }
