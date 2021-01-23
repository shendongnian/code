    class ProcessingManager
    {
        private List<FileProcessor> _processors;
        public void RegisterProcessor(FileProcessor processor)
        {
            _processors.Add(processor)
        }
        ....
