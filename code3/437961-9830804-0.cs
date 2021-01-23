    public FileLogger : ILogger
    {
        public string DirectoryPath { get; set; }
    
        public Write(string Data)
        {
            if (DirectoryPath != null) {
                // Write to file
            }
        } 
    }
