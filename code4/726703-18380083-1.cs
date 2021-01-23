    public void Download(object sender, DoWorkEventArgs e)
            {
                List<File> driveFiles = Google.Apis.Util.Utilities.RetrieveAllFiles(service);
                int fileCount = driveFiles.Count;
                int i = 0;
                IAuthenticator authenticator = new CloudManager().CreateAuthentication();
                foreach (var driveFile in driveFiles.Where(driveFile => driveFile.MimeType != "video/mp4"))
                {
                    LabelFileProcess.Dispatcher.BeginInvoke(DispatcherPriority.Background,
                                                            (Action) (() => LabelFileProcess.Content = driveFile.Title));
                    string title = driveFile.Title;
                    LabelFileProcess.Dispatcher.BeginInvoke(DispatcherPriority.Normal,
                                                            (Action) (() => LabelFileProcess.Content = title));
                    if (string.IsNullOrEmpty(driveFile.Title))
                    {
                        MessageBox.Show(@"File's title is emplty");
                        continue;
                    }
    
                    if (driveFile.MimeType != "application/vnd.google-apps.folder")
                    {
    
                        Stream stream = DownloadFile(authenticator, driveFile);
                        if (stream != null)
                            SaveFile(stream, driveFile.Title);
                    }
                    else
                        Directory.CreateDirectory("D:\\GdriveFiles\\" + driveFile.Title);
                }
    public static System.IO.Stream DownloadFile(IAuthenticator authenticator, File file)
            {
                if (!string.IsNullOrEmpty(file.DownloadUrl))
                    try
                    {
                        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(new Uri(file.DownloadUrl));
                        authenticator.ApplyAuthenticationToRequest(request);
                        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                        return response.StatusCode == HttpStatusCode.OK ? response.GetResponseStream() : null;
                    }
                    catch (Exception e)
                    {
                        System.Windows.Forms.MessageBox.Show("Exception occures " + e.Message);
                    }
                else
                    System.Windows.Forms.MessageBox.Show(@"File doesn't have any content on Drive, Title: "+file.Title);
                return null;
            }
    
            public static void SaveFile(System.IO.Stream stream, String title)
            {
                StreamReader streamReader = new StreamReader(stream);
                //System.Windows.MessageBox.Show(streamReader.ToString());
                if (stream == null)
                    System.Windows.MessageBox.Show("Error Occured during download");
                else
                {
    
    
                    FileStream fileStream = System.IO.File.Create("D:\\GdriveFiles\\" + title);
                    char[] charArray = new char[100];
                    int count;// = streamReader.Read(arrayByte, 0, 100);
                    //streamReader.Read(arrayByte, 0, (int)stream.Length);
                    //fileStream.Write(arrayByte,0,arrayByte.Length);
                    string incomingMessage = "";
                    do
                    {
                        try
                        {
                            count = streamReader.Read(charArray, 0, 100);
                            incomingMessage += new string(charArray, 0, count);
                            byte[] byteArray = new byte[charArray.Length];
                            //byteArray = System.Text.Encoding.Unicode.GetBytes(charArray);
                            byteArray = System.Text.Encoding.ASCII.GetBytes(charArray);
                            fileStream.Write(byteArray, 0, count);
                        }
                        catch (ArgumentException ex)
                        {
                            MessageBox.Show(@"File ended, Exception:" + ex.Message);
                            break;
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show("Exception occure" + e.Message);
                            break;
                        }
    
                    } while (count > 0);
                    fileStream.Close();
                    //MessageBox.Show("File Contains are " + incomingMessage);
                }
            }
