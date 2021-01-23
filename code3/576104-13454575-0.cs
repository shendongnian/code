    static class tags 
    {
        public static Int32 TAG_A = -1;
        public static Int32 TAG_B  = 0x00;
        public static Int32 TAG_C = 0xC1;
        // ...
    }
    [DllImport ("mylibraryname")]
    public static extern int myfunction(Int32 t);
    myfunction(tags.TAG_B);
