    private byte[] DeriveKey(SecureString password, byte[] salt, int iterations, int keyByteLength)
    {
        IntPtr ptr = Marshal.SecureStringToBSTR(password);
        byte[] passwordByteArray = null;
        try
        {
            int length = Marshal.ReadInt32(ptr, -4);
            passwordByteArray = new byte[length];
            GCHandle handle = GCHandle.Alloc(passwordByteArray, GCHandleType.Pinned);
            try
            {
                for (int i = 0; i < length; i++)
                {
                    passwordByteArray[i] = Marshal.ReadByte(ptr, i);
                }
    
                using (var rfc2898 = new Rfc2898DeriveBytes(passwordByteArray, salt, iterations))
                {
                    return rfc2898.GetBytes(keyByteLength);
                }
            }
            finally
            {
                Array.Clear(passwordByteArray, 0, passwordByteArray.Length);  
                handle.Free();
            }
        }
        finally
        {
            Marshal.ZeroFreeBSTR(ptr);
        }
    }
