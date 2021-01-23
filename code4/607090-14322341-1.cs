    private class FileProcessor
    {
        public Boolean IsAlive()
        {
            return ((m_Thread != null) && m_Thread.IsAlive);
        }
        public Boolean FinishedLoading()
        {
            return ((m_Thread == null) || m_Thread.Join(10));
        }
        public AnimationsLoader(Int32 year)
        {
            m_Thread = new Thread(Load);
            m_Thread.Name = "Background File Processor";
        }
        // Then in the Load() method you browse the proper year folder getting all the files and you read/process them in a sequence...
