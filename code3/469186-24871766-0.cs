    // compatible Windows Phone 7.1, 8.0 and 8.1
    public static string CalculateSHA1(string str)
    {
        var bytes = Encoding.UTF8.GetBytes(str);
        byte[] sha1Bytes;
        using (var algorithm = new SHA1Managed())
            sha1Bytes = algorithm.ComputeHash(bytes);
        return BitConverter.ToString(sha1Bytes).Replace("-", "").ToLowerInvariant();
    }
