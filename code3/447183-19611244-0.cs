            /// <summary>
            /// Formats a number using a format string without rounding.
            /// </summary>
            /// <param name="value"></param>
            /// <param name="formatString"></param>
            /// <returns></returns>
            public static string Format(object value, string formatString)
            {
                double val;
    
                if (!Double.TryParse(value.ToString(), out val))
                {
                    return "";
                }
    
                // Special handling for decimals
                if (formatString.Contains("."))
                {
                    int multiplier = (int)Math.Pow(10, getDecimalPlaces(formatString) + 1);
    
                    // Handle percentage
                    if (!formatString.Contains('%'))
                    {
                        multiplier /= 100;
                    }
    
                    return (Math.Truncate(val * multiplier) / multiplier).ToString(formatString); // prevent rounding by truncating
                }
    
                return val.ToString(formatString);
            }
