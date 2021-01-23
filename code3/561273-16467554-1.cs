    public void byte[] Load(string fileName)
    {
        Byte[] retVal = null;
        Uri uri = new Uri(fileName);
        if(uri.Scheme == "file")
        {
            retVal = File.ReadAllBytes(uri.LocalPath);
        }
        else
        {
            var client = new WebClient();
            retVal = client.DownloadData(uri);
        }
        return retVal;
    }
