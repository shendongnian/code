    public static string BytesAsString(byte[] bytes)
    {
        string hex = BitConverter.ToString(bytes); // This puts "-" between each value.
        return hex.Replace("-","");                // So we remove "-" here.
    }
