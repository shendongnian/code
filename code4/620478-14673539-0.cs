    public abstract class FileSystem
    {
         public abstract bool FileExists(string fullPath);
         public abstract Stream OpenFile(string fullPath, FileMode mode, FileAccess access);
    }
