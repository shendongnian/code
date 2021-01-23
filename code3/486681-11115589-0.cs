    protected void Page_Load(object sender, EventArgs e)
    {
        if (!GetSem_SomeoneIsDownloading())
        {
            PerformDownload();
            ClearSem_SomeoneIsDownloading();
        }
        else
        {
            DisplayMessageSomeoneIsDownloadingAlready();
        }
    }
    
    bool GetSem_SomeoneIsDownloading()
    {
        bool isSomeoneDownloading;
        Application.Lock();
    
        isSomeoneDownloading = (bool)(Application["SomeoneIsDownloading"] ?? false);
        if (!isSomeoneDownloading)
            Application["SomeoneIsDownloading"] = true;
    
        Application.UnLock();
        return isSomeoneDownloading;
    }
    
    void ClearSem_SomeoneIsDownloading()
    {
        Application.Lock();
        Application["SomeoneIsDownloading"] = false;
        Application.UnLock();
    }
