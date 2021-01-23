    public static IEnumerable<FileSystemInfo> SafeGetFileSystemInfosRecursive(DirectoryInfo directory, string searchPattern)
    {
        try
        {
            return directory
                .EnumerateFileSystemInfos(searchPattern)
                .Concat(
                    directory
                        .EnumerateDirectories()
                        .SelectMany(x => SafeGetFileSystemInfosRecursive(x, searchPattern))
                );
        }
        catch (UnauthorizedAccessException)
        {
            return Enumerable.Empty<FileSystemInfo>();
        }
    }
