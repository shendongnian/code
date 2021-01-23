    /// <summary>
    /// Returns the byte array as a string, or null
    /// </summary>
    public static string GetByteString(byte[] b)
    {
        if (b == null) return null;
        return Encoding.UTF8.GetString(b);
    }
