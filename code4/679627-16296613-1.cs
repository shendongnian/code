    public bool ftpTransfer(string fileName)
    {
        try
        {
            string ftpAddress = "127.0.0.1";
            string username = "user";
            string password = "pass";
           
            using (StreamReader stream = new StreamReader("C:\\" + fileName))
            {
                byte[] buffer = Encoding.Default.GetBytes(stream.ReadToEnd());
                WebRequest request = WebRequest.Create("ftp://" + ftpAddress + "/" + "myfolder" + "/" + fileName);
                request.Method = WebRequestMethods.Ftp.UploadFile;
                request.Credentials = new NetworkCredential(username, password);
                Stream reqStream = request.GetRequestStream();
                reqStream.Write(buffer, 0, buffer.Length);
                reqStream.Close();
            }
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            return false;
        }
    }
