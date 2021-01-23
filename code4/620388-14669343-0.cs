    public string saveImages(string picUrl, string path)
    {
                this.wc.DownloadFile(picUrl, path + p);
                return picUrl + " is downloaded to folder " + path + ".";
    }
