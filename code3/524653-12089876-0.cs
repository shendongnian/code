    private static void ExtractFromUrl(Uri uri, string directoryPath)
    {
        using (var webClient = new WebClient())
        using (var stream = webClient.OpenRead(uri))
        using (var zipFile = ZipFile.Read(stream))
        {
            zipFile.ExtractAll(directoryPath);
        }
    }
