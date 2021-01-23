    public interface IDirectory
    {
        bool IsDirectoryEmplty(string path);
    }
    public class Directory : IDirectory
    {
        [DllImport("Shlwapi.dll", EntryPoint = "PathIsDirectoryEmpty")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool IsDirectoryEmplty([MarshalAs(UnmanagedType.LPStr)]string directory);
        bool IInterface.IsDirectoryEmplty(string path)
        {
            return IsDirectoryEmplty(path);
        }
    }
