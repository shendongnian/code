    public unsafe static int ByPtr754_64(ulong bits) {
        var fp = (double)bits;
        return ((int)(*(ulong*)&fp >> 52) & 2047) - 1023;
    }
    public static int ByILogB(ulong bits) {
        return Math.ILogB(bits);
    }
