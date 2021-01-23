    public static byte[] GetBytes(ValueType obj)
    {
        Type tObj = obj.GetType();
        Type tBitConverter = typeof(BitConverter);
        
        if (tObj == typeof(byte))
            return new byte[] { (byte)obj };
        MethodInfo miGetBytes = tBitConverter.GetMethod("GetBytes", new Type[] { tObj });
        return (byte[])miGetBytes.Invoke(null, new object[] { obj });
    }
