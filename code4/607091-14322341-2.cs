    private List<FileProcessor> m_FileProcessors = new List<FileProcessor>();
    public FilesProcessor()
    {
        for (Int32 year = 2005; year < DateTime.Now.Year; ++year)
            InstanciateFileProcessor(year);
        while (!FinishedLoading())
            Application.DoEvents();
    }
    private Boolean FinishedLoading()
    {
        foreach (FileProcessor processor in m_FileProcessors)
        {
            if (processor.IsAlive() && !processor.FinishedLoading())
                return false;
        }
        return true;
    }
    private void InstanciateFileProcessor(Int32 year)
    {
        FileProcessor processor = new FileProcessor(year);
        processor.Start();
        m_FileProcessors.Add(processor);
    }
