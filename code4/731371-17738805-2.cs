    private static readonly string[] _validExtensions = {"jpg","bmp","gif","png"}; //  etc
    public static bool IsImageExtension(string ext)
    {
        return _validExtensions.Contains(ext.ToLower());
    }
