                byte[] data;
                if (url.Trim().StartsWith("file://"))
                {                    
                    string fileName = url.Replace("file://","");
                    data = File.ReadAllBytes(fileName);
                }
                else
                {
                    WebClient wc = new WebClient();
                    //wc.Proxy = GlobalProxySelection.GetEmptyWebProxy();
                    data = wc.DownloadData(url);
                }
                // process data...   
                   
