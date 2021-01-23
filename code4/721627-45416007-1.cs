    try
            {
                WebRequest request = WebRequest.Create("ftp://" + ftpServerIP + "/outbox");
                request.Credentials = new NetworkCredential("user", "password");
                request.Method = WebRequestMethods.Ftp.MakeDirectory;
                using (var resp = (FtpWebResponse)request.GetResponse())
                {
                    Console.WriteLine(resp.StatusCode);
                }
            }
            catch (WebException ex)
            {
                FtpWebResponse response = (FtpWebResponse)ex.Response;
                if (response.StatusCode == FtpStatusCode.ActionNotTakenFileUnavailable)
                {
                    response.Close();
                    //already exists
                }
                else
                {
                    response.Close();
                    //doesn't exists = it's another exception
                }
            }
