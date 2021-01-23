    public static double LogBase2(byte[] bytes)
    {
        byte MSB = bytes[bytes.Length - 1];
        if (MSB >= 128) return 0; // -ve bigint
        if (MSB == 0) return bytes.Length * 8 - 9; // {...,128,0}
        return System.Math.Log(MSB,2) + ((bytes.Length - 1) * 8);
    }
