    public static class StringHelpers
    {
        public static string ToReverse( this string s )
        {
            char[] buf = new char[s.Length] ;
            int    i   = 0        ; 
            int    j   = s.Length ;
            while ( j > 0 )
            {
                buf[i++] = s[--j] ;
            }
            return new string(buf) ;           
        }
    }
