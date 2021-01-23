    public static void sampleUpload()
    {
        // Get the object used to communicate with the server.
        FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://100.165.80.15:21/output/Group Dealer, Main Dealer, Zone, Branch, and Destination Report_20120927105003.pdf");
        request.Method = WebRequestMethods.Ftp.UploadFile;
        request.UseBinary = true;
        // This example assumes the FTP site uses anonymous logon.
        request.Credentials = new NetworkCredential("toc", "fid123!!");
        // Copy the contents of the file to the request stream.
        byte[] b = File.ReadAllBytes(sourceFile);
        request.ContentLength = b.Length;
        using (Stream s = request.GetRequestStream())
        {
            s.Write(b, 0, b.Length);
        }
        FtpWebResponse response = (FtpWebResponse)request.GetResponse();
        Console.WriteLine("Upload File Complete, status {0}", response.StatusDescription);
        response.Close();
    }
