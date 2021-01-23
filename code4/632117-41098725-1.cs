    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    public static class StringExtensions
    {
        public static bool EqualsAny(this string target, StringComparer comparer, params string[] values)
        {
            return target.EqualsAny(comparer, (IEnumerable<string>) values);
        }
    
        public static bool EqualsAny(this string target, params string[] values)
        {
            return target.EqualsAny((IEnumerable<string>)values);
        }
    
        public static bool EqualsAny(this string target, StringComparer comparer, IEnumerable<string> values)
        {
            return values.Contains(target, comparer);
        }
    
        public static bool EqualsAny(this string target, IEnumerable<string> values)
        {
            return values.Contains(target, StringComparer.OrdinalIgnoreCase);
        }
    }
