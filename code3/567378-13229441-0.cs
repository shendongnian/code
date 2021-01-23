    try
                {
                    Uri URL2 = new Uri(@"http://www.*****.com");
                    HttpWebRequest request2 = (HttpWebRequest)WebRequest.Create(URL2);
                    request2.Timeout = 100;
                    HttpWebResponse response2 = (HttpWebResponse)request2.GetResponse();
                }
                catch (WebException e)
                {
                    MessageBox.Show(e.Message.ToString());
                }
