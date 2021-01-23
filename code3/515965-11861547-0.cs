            public void PoolAndDownloadFile(Uri uri, string filePath)
            {
                WebClient webClient = new WebClient();
                byte[] downloadedBytes = webClient.DownloadData(uri);
                while (downloadedBytes.Length == 0)
                {
                    Thread.Sleep(2000);
                    downloadedBytes = webClient.DownloadData(uri);
                }
                Stream file = File.Open(filePath, FileMode.Create);
                file.Write(downloadedBytes, 0, downloadedBytes.Length);
                file.Close();
            }
