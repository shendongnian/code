    public static Random CreateRandom()
    {
    	using (var rng = new System.Security.Cryptography.RNGCryptoServiceProvider())
    	{
    		byte[] bytes = new byte[4];
    		rng.GetNonZeroBytes(bytes);
    		int seed = BitConverter.ToInt32(bytes, 0);
    		return new Random(seed);
    	}
    }
