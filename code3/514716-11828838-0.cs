    private readonly Lazy<Progress> m_progress;
    public MyType()
    {
        m_progress = new Lazy<Progress>(() =>
        {
            long totalBytes = m_transferManager.TotalSize();
            return new Progress(totalBytes);
        });
    }
