    public static bool SearchByteByByte(byte[] bytes, byte[] pattern)
    {
        bool found = false;
        int matchedBytes = 0;
        for (int i = 0; i < bytes.Length; i++)
        {
                    
            if (pattern[0] == bytes[i] && bytes.Length - i >= pattern.Length)
            {
                        
                for (int j = 0; j < pattern.Length; j++) // start from 0
                {
                    if (bytes[i + j] == pattern[j]) 
                    {
                        matchedBytes++;
                        if (matchedBytes == pattern.Length) // remove - 1                    
                            return true;
                        
                        continue;
                    }
                    else
                    {
                        matchedBytes = 0;
                        break;
                    }
                }
            }
        }
        return found;
    }
