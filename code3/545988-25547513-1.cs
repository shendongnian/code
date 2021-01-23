     public static void DownloadFile(string userName, string password, string fileUrl, string filePath)
     {
            var securePassword = new SecureString();
            foreach (var c in password)
            {
                securePassword.AppendChar(c);
            }
            using (var client = new WebClient())
            {
                client.Credentials = new SharePointOnlineCredentials(userName, securePassword);
                client.Headers.Add("X-FORMS_BASED_AUTH_ACCEPTED", "f");
                client.DownloadFile(fileUrl, filePath);
            }
    }
