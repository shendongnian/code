    static void _Casting()
    {
        int i = 10;
        float f = 0;
        f = i;  // An implicit conversion, no data will be lost.
        f = 0.5F;
        i = (int)f;  // An explicit conversion. Information will be lost.
    }
