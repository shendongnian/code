    using System;
    
    namespace MyLibrary
    {
        public static class StringExtensions
        {
            public static Int32? AsInt32(this string s)
            {
                Int32 result;
            
                return Int32.TryParse(s, out result) ? result : (Int32?)null;
            }
            
            public static bool IsInt32(this string s)
            {
                return s.AsInt32().HasValue;
            }
            
            public static Int32 ToInt32(this string s)
            {
                return Int32.Parse(s);
            }
        }
    }
