    public static bool ConformsToPattern(System.Numerics.BigInteger number)
    {
        bool foundStart = false;
        bool foundEnd = false;
        if (!number.IsEven)            
            return false;
        while (!number.IsZero)
        {
            if (!foundEnd)
            {
                if (!number.IsEven)
                    foundEnd = true;
                number = number >> 1;
                continue;                
            }
            if (!foundStart)
            {
                if (number.IsEven)                
                    foundStart = true;
                number = number >> 1;
                continue;                
            }
            return false;
        }
        if (foundEnd)
            return true;
        return false;
    }
