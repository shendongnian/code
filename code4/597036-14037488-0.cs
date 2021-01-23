    private static readonly RNGCryptoServiceProvider _crypto = new RNGCryptoServiceProvider();
    public static long Generate(){
        // use whatever size you want here; bigger has a better chance of 
        // being unique in a given scope
        byte[] bytes = new byte[8];
    
        // puts random bytes into the array
        _crypto.GetBytes( bytes );
    
        // do something (your choice) with the value...
        return BitConverter.ToInt64( bytes, 0 );
    }
