    private void FtpTransfer(string siteName, string portNumber, string ftpUser, string ftpPassword, string destPath)
            {
                DateTime now = DateTime.Now;
                string now_string =
                    (now.Year).ToString()
                    + "_" +
                    (now.Month).ToString("0#")
                    + "_" +
                    (now.Day).ToString("0#");
    
                foreach (object item in listBox1.Items)
                {
                    string srcFile = item.ToString();
                    lblSource.Text = srcFile;
                    Uri uri = new Uri(srcFile);
                    string destFile = srcFile.Replace(lblPath.Text, "").Replace("\\\\", "\\").Replace("\\", "/").Replace("www/", "");
    
                    Configuration oConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    int timeout = int.Parse(oConfig.AppSettings.Settings["TimeOut"].Value);
    
                    if (siteName == "mysite1.co.in" || siteName == "sd1.mysite2.net")
                        destFile = "ftp://" + siteName + ":" + portNumber + "/" + siteName + "/_test" + destFile; //error here
                    else
                        destFile = "ftp://" + siteName + ":" + portNumber + "/" + siteName + destFile; //no error
                    lblDestn.Text = destFile;
    
                    FtpWebRequest request = (FtpWebRequest)WebRequest.Create(destFile);
                    request.Credentials = new NetworkCredential(ftpUser, ftpPassword);
                    request.Timeout = 6000;
                    request.Method = WebRequestMethods.Ftp.UploadFile;
                    request.UsePassive = true;
                    request.UseBinary = true;
                    request.KeepAlive = true;
    
                    // Copy the contents of the file to the request stream.
                    byte[] fileContents;
                    using (StreamReader sourceStream = new StreamReader(@srcFile))
                    {
                        fileContents = Encoding.UTF8.GetBytes(sourceStream.ReadToEnd());
                    }
                    request.ContentLength = fileContents.Length;
    
                    using (Stream requestStream = request.GetRequestStream())
                    {
                        requestStream.Write(fileContents, 0, fileContents.Length);
                    }
    
                    using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
                    {
                        string path = System.IO.Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]);
                        System.IO.StreamWriter w = System.IO.File.AppendText(path + "\\log_" + now_string + ".txt");
                        w.WriteLine(DateTime.Now.ToString("yyy-MM-dd HH:mm:ss")
                                    + " "
                                    + srcFile
                                    + " "
                                    + destFile
                                    + " "
                                    + response.StatusDescription);
    
                    }
                }
    
            }
 
