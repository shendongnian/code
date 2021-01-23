    public static class StringExtension
    {
        public static String Replace(this string self, 
                                          string oldString, string newString, 
                                          bool firstOccurrenceOnly = false)
        {
            if ( !firstOccurrenceOnly )
                return self.Replace(oldString, newString);
            int pos = self.IndexOf(oldString);
            if ( pos < 0 )
                return self;
            return self.Substring(0, pos) + newString 
                   + self.Substring(pos + oldString.Length);
        }
    }
    // Usage:
    var result = pctSign.Replace("/0", "%", true);
