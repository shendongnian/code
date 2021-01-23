    using System;
    using System.Collections.Generic;
    using System.Linq;
    public static class StringExtensions
    {
        public static bool EqualsAny(this string source, StringComparer comparer, params string[] values)
        {
            return source.EqualsAny(comparer, (IEnumerable<string>) values);
        }
        public static bool EqualsAny(this string source, params string[] values)
        {
            return source.EqualsAny((IEnumerable<string>)values);
        }
        public static bool EqualsAny(this string source, StringComparer comparer, IEnumerable<string> values)
        {
            return values.Contains(source, comparer);
        }
        public static bool EqualsAny(this string source, IEnumerable<string> values)
        {
            return values.Contains(source, StringComparer.OrdinalIgnoreCase);
        }
    }
