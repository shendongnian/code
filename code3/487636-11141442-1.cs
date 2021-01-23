    public interface IFileDataSource
    {
       FileStream Open(string path,
                       FileMode mode,
                       FileAccess access,
                       FileShare share);
    }
