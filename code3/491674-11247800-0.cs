    private int roll_hash(byte c)
    {
        h2 -= h1; // same
        h2 += ROLLING_WINDOW * c; // same, remove (uint)
    
        h1 += c; // same
        h1 -= window[n];
    
        window[n] = c;
        if(++n == ROLLING_WINDOW) n = 0; // limit n to 0 to 6 so % is not required.
    
        h3 = (h3 << 5); // same
        h3 ^= c; // same
    
        return h1 + h2 + h3; // same
    }
    
    private static int sum_hash(byte c, int h)
    {
            h *= HASH_PRIME; // same
            h ^= c; // same
            return h;
    }
