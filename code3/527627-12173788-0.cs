         1. don't pool if webclient busy, you have a callback   myWebClientUploadloadFileCompleted
         2. set successfull status in you completed callback not in your method
        
         static ManualResetEvent done = new ManualResetEvent(false);
    
        
              public bool UploadFirmware(string srcPath, string destPath)
                    {
                        bool status = false;
                        List<Unisys.sPar.FirmwareInfo> orgFwList = new List<Unisys.sPar.FirmwareInfo>();
                        List<Unisys.sPar.FirmwareInfo> upFwList = new List<Unisys.sPar.FirmwareInfo>();
                        try
                        {
                            orgFwList = EnumerateFirmware();
                            Uri fwuri = new Uri(destPath);
                            string myStringWebResource = null;
                            WebClient myWebClient = new WebClient();
                            myStringWebResource = fwuri.ToString();
                            myWebClient.Encoding = Encoding.UTF8;
                            myWebClient.Credentials = new NetworkCredential(userName, password);
                            myWebClient.Headers[HttpRequestHeader.ContentType] = "application/zip";
                            bool gExecuteOnce = true;
                            ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(AcceptAllCertifications);
                            myWebClient.UploadFileCompleted += new UploadFileCompletedEventHandler(myWebClientUploadloadFileCompleted);
                            myWebClient.UploadFileAsync(new System.Uri(myStringWebResource), "POST", srcPath);//upload method 
                           
                          done.WaitOne();//wait signal from completed callback
                
                        }
                        catch (Exception ex)
                        {
                            status = false;
                            SPARTestToolInit.logger.Log(NLog.LogLevel.Error, "Unable to upload firmware due to " + ex.ToString());
                        }
                
                        return status;
                    }
    
    
    static void client_UploadFileCompleted(object sender, UploadFileCompletedEventArgs e)
        {
            done.Set();
        }
    
    static void client_UploadProgressChanged(object sender, UploadProgressChangedEventArgs e)
        {
            //set your progress log
        }
