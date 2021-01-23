    [DllImport("mscoree.dll", CharSet = CharSet.Unicode)]
    private static extern int GetFileVersion(string path, StringBuilder buffer, int buflen, out int written);
    public static bool IsDotNetExecutable(string path)
    {
        StringBuilder sBuilder = new StringBuilder(256);
        int written;
        int gvf = GetFileVersion(path, sBuilder, sBuilder.Capacity, out written);
        return gvf == 0;
    }
