        this is code use to get the list of files in the ftp
        private void ftpFileRead()
        {
        FtpWebRequest Request = (FtpWebRequest)WebRequest.Create("your ftpAddress");
        Request.Method = WebRequestMethods.Ftp.ListDirectory;     
        Request.Credentials = new NetworkCredential(your ftp username,your ftp password);
        FtpWebResponse Response = (FtpWebResponse)Request.GetResponse();
        Stream ResponseStream = Response.GetResponseStream();
        StreamReader Reader = new StreamReader(ResponseStream);
        ListBox1.Items.Add(Response.WelcomeMessage);
        while (!Reader.EndOfStream)//Read file name   
        {
            ListBox1.Items.Add(Reader.ReadLine().ToString());
        }
        Response.Close();
        ResponseStream.Close();
        Reader.Close();
}
