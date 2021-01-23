    public static bool SearchByteByByte(byte[] bytes, byte[] pattern)
    {
        for (int i = 0; i < bytes.Length; i++)
        {
            if (bytes.Length - i < pattern.Length)
                return false;
    
            if (pattern[0] != bytes[i])
                continue;
    
            for (int j = 0; j < pattern.Length; j++)
            {
                if (bytes[i + j] != pattern[j])
                    break;                    
                        
                if (j == pattern.Length - 1)
                    return true;
            }
        }
    
        return false;
    }
