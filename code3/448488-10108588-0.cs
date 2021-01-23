        public static int getNumberic( char c )
        {
            if( c >= 'a' && c <= 'z' )
            {
                return c - 'a';
            }
            else if( c >= '0' && c <= '9' )
            {
                return 'z' + c - '0';
            }
            else
            {
                return 1000;
            }
        }
