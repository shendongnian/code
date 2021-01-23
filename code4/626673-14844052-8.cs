    // RNGCryptoServiceProvider is thread safe in .NET 3.5 and above
    // .NET 3.0 and below will need locking to protect access
    private static readonly RNGCryptoServiceProvider random =
        new RNGCryptoServiceProvider();
    public /*virtual*/ byte[] GenerateNonce(int length)
    {
        // a default length could be specified instead of being parameterized
        var data = new byte[length];
        random.GetNonZeroBytes(data);
        return data;
    }
    // or
    public /*virtual*/ string GenerateNonce(int length)
    {
        var data = new byte[length];
        random.GetNonZeroBytes(data);        
        return Convert.ToBase64String(data);
    }
