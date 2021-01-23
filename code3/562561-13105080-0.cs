            WebClient client = new WebClient();
            using (MemoryStream download = new MemoryStream(client.DownloadData(url)))
            {
                using (StreamReader dataReader = new StreamReader(download, System.Text.Encoding.Default, true))
                {
                    return dataReader;
                }
            }
