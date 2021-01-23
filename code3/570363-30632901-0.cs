        /// <summary>
        /// Extensions for String
        /// </summary>
        public static class StringExtenions
        {
            public static string SafeTrim(this string input)
            {
                if (input.IsNotEmpty())
                {
                    return input.Trim();
                }
    
                return input;
            }
    
            /// <summary>
            /// Checks to see if a given string is empty.
            /// </summary>        
            public static bool IsEmpty(this string input)
            {
                return string.IsNullOrEmpty(input);
            }
    
            /// <summary>
            /// Checks to see if a given string is not empty.
            /// </summary>        
            public static bool IsNotEmpty(this string input)
            {
                return !string.IsNullOrEmpty(input);
            }
    
            /// <summary>
            /// Converts text to title case.
            /// </summary>
            /// <param name="input"></param>
            /// <returns></returns>
            public static string ToTitleCase(this string input)
            {
                CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;            
                TextInfo textInfo = cultureInfo.TextInfo;
                
                return textInfo.ToTitleCase(input.ToLower());
            }
        }
