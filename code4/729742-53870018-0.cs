        public class FolderNotEmptyException : Exception
    {
        public FolderNotEmptyException(string Path) : base($"Directory is not empty. '{Path}'.")
        { }
        public FolderNotEmptyException(string Path, Exception InnerException) : base($"Directory is not empty. '{Path}'.", InnerException)
        { }
    }
