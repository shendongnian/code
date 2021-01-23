    public static class ZipArchiveExtension
    {
        public static ZipArchiveDirectory CreateDirectory(this ZipArchive @this, string directoryPath)
        {
            return new ZipArchiveDirectory(@this, directoryPath);
        }
    }
    public class ZipArchiveDirectory
    {
        private readonly string _directory;
        private ZipArchive _archive;
        internal ZipArchiveDirectory(ZipArchive archive, string directory)
        {
            _archive = archive;
            _directory = directory;
        }
        public ZipArchive Archive { get; private set; }
        public ZipArchiveEntry CreateEntry(string entry)
        {
            return Archive.CreateEntry(_directory + "//" + entry);
        }
        public ZipArchiveEntry CreateEntry(string entry, CompressionLevel compressionLevel)
        {
            return Archive.CreateEntry(_directory + "//" + entry, compressionLevel);
        }
    }
