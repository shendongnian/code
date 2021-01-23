    public static class ExtensionFunctions{
        public static string ToStringOrNull( this object target ) {
            return target != null ? target.ToString() : null;
        }
    }
