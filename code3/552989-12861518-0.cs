    public static class ExtensionFunctions{
        public static string ToStringOrNull( this object target ) {
            if ( target != null )
                return target.ToString();
            return null;
        }
    }
