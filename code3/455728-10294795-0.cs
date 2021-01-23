                WebClient m_webClient = new WebClient();
                Uri m_uri = new Uri("http://URL");
                m_webClient.OpenReadCompleted += new OpenReadCompletedEventHandler(webClient_OpenReadCompleted);
                m_webClient.OpenReadAsync(m_uri);
                
                
            }
                    
        void webClient_OpenReadCompleted(object sender, OpenReadCompletedEventArgs e)
        {
            int count;
            Stream stream = e.Result;
            byte[] buffer = new byte[1024];
            using (IsolatedStorageFile isf = IsolatedStorageFile.GetUserStoreForApplication())
            {
                
                using (System.IO.IsolatedStorage.IsolatedStorageFileStream isfs = new IsolatedStorageFileStream("IMAGES.jpg", FileMode.Create, isf))
                {
                    count = 0;
                    while (0 < (count = stream.Read(buffer, 0, buffer.Length)))
                    {
                        isfs.Write(buffer, 0, count);
                    }
                    stream.Close();
                    isfs.Close();
                }
            }
