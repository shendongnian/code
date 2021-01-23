    public static double LogBase2 (byte [] bytes)
    {
        
        return (bytes[bytes.Length-1]>0) ?
               (System.Math.Log(bytes [bytes.Length-1], 2) + ((bytes.Length - 1) * 8))
             : (System.Math.Log(bytes [bytes.Length-2], 2) + ((bytes.Length - 2) * 8));
    }
