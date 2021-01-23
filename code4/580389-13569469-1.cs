    /// <summary>
    /// Gets a hash of the file using SHA1.
    /// </summary>
    /// <param name="filePath"></param>
    /// <returns></returns>
    public static string GetSHA1Hash(string filePath)
    {
        using (var sha1 = new SHA1CryptoServiceProvider())
            return GetHash(filePath, sha1);
    }
    /// <summary>
    /// Gets a hash of the file using SHA1.
    /// </summary>
    /// <param name="filePath"></param>
    /// <returns></returns>
    public static string GetSHA1Hash(Stream s)
    {
        using (var sha1 = new SHA1CryptoServiceProvider())
            return GetHash(s, sha1);
    }
    /// <summary>
    /// Gets a hash of the file using MD5.
    /// </summary>
    /// <param name="filePath"></param>
    /// <returns></returns>
    public static string GetMD5Hash(string filePath)
    {
        using (var md5 = new MD5CryptoServiceProvider())
            return GetHash(filePath, md5);
    }
    /// <summary>
    /// Gets a hash of the file using MD5.
    /// </summary>
    /// <param name="filePath"></param>
    /// <returns></returns>
    public static string GetMD5Hash(Stream s)
    {
        using (var md5 = new MD5CryptoServiceProvider())
            return GetHash(s, md5);
    }
    private static string GetHash(string filePath, HashAlgorithm hasher)
    {
        using (var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            return GetHash(fs, hasher);
    }
    private static string GetHash(Stream s, HashAlgorithm hasher)
    {
        var hash = hasher.ComputeHash(s);
        var hashStr = Convert.ToBase64String(hash);
        return hashStr.TrimEnd('=');
    }
