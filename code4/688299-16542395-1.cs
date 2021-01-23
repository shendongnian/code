    public class FileHandler : IFileHandler
    {
         public string GetFilename(string name)
         {
             return System.IO.GetFileName(name);
         }
        public string GetDirectoryName(string directory)
        {
             return System.IO.GetDirectoryName(directory);
        }
    }
    public interface IFileHandler
    {
          string GetFilename(string name);
          string GetDirectoryName(string directory);
    }
