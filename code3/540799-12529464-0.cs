    return getDigits(...)
----------
    public static int getDigits(int digits, int i)
    {
        if (digits != 0)
        {
            i++;
            getDigits(digits/10, i);                
        }
    
        return i;
    }
