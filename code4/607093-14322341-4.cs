    public static class FilesProcessor
    {
        private static List<FileProcessor> m_FileProcessors;
        public static void Start()
        {
            m_FileProcessors = new List<FileProcessor>();
            for (Int32 year = 2005; year < DateTime.Now.Year; ++year)
                InstanciateFileProcessor(year);
            while (!FinishedLoading())
                Application.DoEvents();
        }
        public static void Stop()
        {
            foreach (FileProcessor processor in m_FileProcessors)
                processor.Stop()
            m_FileProcessors.Clear();
            m_FileProcessors = null;
        }
        private static Boolean FinishedLoading()
        {
            foreach (FileProcessor processor in m_FileProcessors)
            {
                if (processor.IsAlive() && !processor.FinishedLoading())
                    return false;
            }
            return true;
        }
        private static void InstanciateFileProcessor(Int32 year)
        {
            FileProcessor processor = new FileProcessor(year);
            processor.Start();
            m_FileProcessors.Add(processor);
        }
    }
