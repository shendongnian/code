    public static void DownloadFile(string userName, SecureString securePassword,string fileUrl,string filePath)
    {
        using (var client = new WebClient())
        {
           client.Credentials = new SharePointOnlineCredentials(userName, securePassword);
           client.Headers.Add("X-FORMS_BASED_AUTH_ACCEPTED", "f");
           client.DownloadFile(fileUrl, filePath);
        }
     }
