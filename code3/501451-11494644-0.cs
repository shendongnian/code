    // It Will Download The XML Once To Use further to Avoid Again And Again Calls For Each Time
     
    public void GetXML(string path)
                {
                    WebClient wcXML = new WebClient();
                    wcXML.OpenReadAsync(new Uri(path));
                    wcXML.OpenReadCompleted += new OpenReadCompletedEventHandler(webClient);
                }
    void webClient(object sender, OpenReadCompletedEventArgs e)
            {
                if (e.Error == null)
                {
                    try
                    {
                        Stream Resultstream = e.Result;
                        XmlReader reader = XmlReader.Create(Resultstream);
    
                            var isolatedfile = IsolatedStorageFile.GetUserStoreForApplication();
                            using (IsolatedStorageFileStream stream = new IsolatedStorageFileStream("Download.xml", System.IO.FileMode.Create, isolatedfile))
                            {
                                byte[] buffer = new byte[e.Result.Length];
                                while (e.Result.Read(buffer, 0, buffer.Length) > 0)
                                {
                                    stream.Write(buffer, 0, buffer.Length);
                                }
                                stream.Flush();
                                System.Threading.Thread.Sleep(0);
                            }
                    }
    
                    catch (Exception ex)
                    {
                        //Log Exception
                    }
                }
    
                if (e.Error != null)
                {
                    //Log Exception
                }
            }
    // This Method Will Give You Required Info According To Your Tag Like "Achievement123"
    
    protected List<DownloadInfo> GetDetailFromXML(string TagName)
            {
                //TagName Like "achivement23"
                List<DownloadInfo> listDetails = new List<DownloadInfo>();
    
                XDocument loadedData;
                try
                {
                    using (var storage = IsolatedStorageFile.GetUserStoreForApplication())
                    {
                        // Check For Islated Storage And Load From That
                        if (storage.FileExists("Download.xml"))
                        {
                            using (Stream stream = storage.OpenFile("Download.xml", FileMode.Open, FileAccess.Read))
                            {
                                loadedData = XDocument.Load(stream);
                                //TagName Like "achivement23"
                                listDetails.AddRange((from query in loadedData.Element("GOW1").Elements(TagName)
                                                      select new DownloadInfo
                                                      {
                                                          TITLE = (string)query.Element("TITLE"),
                                                          DESCRIPTION = (string)query.Element("DESCRIPTION"),
                                                          ACHIVEMENTIMAGE = (string)query.Element("ACHIVEMENTIMAGE"),
                                                          GUIDE = (string)query.Element("GUIDE"),
                                                          YOUTUBELINK = (string)query.Element("YOUTUBELINK")
                                                      }).ToList());
                            }
                        }
                    }
                    return listDetails;
                }
                catch (Exception ex)
                {
                    return listDetails = null;
                    //Log Exception
                }
            }
    
            public class DownloadInfo
            {
                public string TITLE { get; set; }
                public string DESCRIPTION { get; set; }
                public string GUIDE { get; set; }
                public string ACHIVEMENTIMAGE { get; set; }
                public string YOUTUBELINK { get; set; }
            }
