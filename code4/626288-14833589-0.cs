    private volatile Task<string> m_cachedWebServiceTask;
    async Task<string> AccessWebServiceAsync()
    {
        var task = m_cachedWebServiceTask;
        if (task == null)
            task = m_cachedWebServiceTask = DownloadFromWebServiceAsync();
        try
        {
            return await task;
        }
        finally
        {
            m_cachedWebServiceTask = null;
        }
    }
