    abstract class FileProcessor 
    {
        public FileProcessor() 
        {
        }
        public abstract Process(string path);
        public abstract bool CanHandle(string path);
    }
