        // Get the request using a specific URI 
        static public FtpWebRequest GetWebRequest(string method, string uri)
        {
            Uri serverUri = new Uri(uri);
            **if (serverUri.ToString().Contains("#"))
            {
                serverUri = new Uri(serverUri.ToString().Replace("#", Uri.HexEscape('#')));
            }**
            Console.WriteLine(serverUri.ToString());
            if (serverUri.Scheme != Uri.UriSchemeFtp)
            {
                return null;
            }
            try
            {
                var reqFTP = (FtpWebRequest)FtpWebRequest.Create(serverUri);
                reqFTP.Method = method;
                reqFTP.UseBinary = true;
                reqFTP.Credentials = new NetworkCredential(userId, password);
                reqFTP.Proxy = null;
                reqFTP.KeepAlive = false;
                reqFTP.UsePassive = false;
                return reqFTP;
            }
            catch (Exception ex)
            {
                logWriter.WriteLog("Get Web Request: ", "Cannot connect to " + uri + "\n" + "Error: " + ex.Message);
                return null;
            }
        }
