     public class FileInfoAbstraction
     {
          protected FileInfo _fileInfo = null;
          public virtual string Extension
          {
              get { return _fileInfo.Extension; }
          }
          public FileInfoAbstraction(string path)
          {
              _fileInfo = new FileInfo(path);
          }
     }
