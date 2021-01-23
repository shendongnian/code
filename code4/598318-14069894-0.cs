    public static class AccessExtensions
    {
        public static Guid GetGuidOrEmpty( this IDbReader reader, string columnName )
        {
            // all the code to check for DBNull and conversions goes here
            // ...
            return hasValue ? value : Guid.Empty;
        }
    }
