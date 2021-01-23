    public class BclFileDataSource : IFileDataSource
    {
        public FileStream Open(string path,
                               FileMode mode,
                               FileAccess access,
                               FileShare share)
        {
            return File.Open(path, mode, access, share);
        }
    }
