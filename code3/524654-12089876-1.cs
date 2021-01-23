    private static void ExtractFromUrl(Uri uri, string directoryPath)
    {
        using (var webClient = new WebClient())
        {
            var data = webClient.DownloadData(uri);
            using (var memoryStream = new MemoryStream(data))
            using (var zipFile = ZipFile.Read(memoryStream))
            {
                zipFile.ExtractAll(directoryPath);
            }                
        }
    }
