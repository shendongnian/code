    public static class SharedUtils
    {
        public static string FormatWith( this string format, params object[] args )
        {
            if( format == null )
                throw new ArgumentNullException( "format" );
            return String.Format( format, args );
        }
    }
