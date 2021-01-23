<!-- -->
    public static string HashPassword(string input)
    {
        var sha1 = SHA1Managed.Create();
        byte[] inputBytes = Encoding.ASCII.GetBytes(input);
        byte[] outputBytes = sha1.ComputeHash(inputBytes);
        return BitConverter.ToString(outputBytes).Replace("-", "").ToLower();
    }
