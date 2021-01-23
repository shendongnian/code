    public bool directoryExists(string directory)
    {
        /* Create an FTP Request */
        ftpRequest = (FtpWebRequest)FtpWebRequest.Create(host + "/" + directory);
        /* Log in to the FTP Server with the User Name and Password Provided */
        ftpRequest.Credentials = new NetworkCredential(user, pass);
        /* Specify the Type of FTP Request */
        ftpRequest.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
        try
        {
            using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
            {
                return true;
            }
        }
        catch (Exception ex)
        {
            return false;
        }
                /* Resource Cleanup */
        finally
        {
            ftpRequest = null;
        }
    }
