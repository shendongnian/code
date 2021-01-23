    public static class RomanNumber {
            static string[] units = { "", "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX" };
            static string[] tens = { "", "X", "XX", "XXX", "XL", "L", "LX", "LXX", "LXXX", "XC" };
            static string[] hundreds = { "", "C", "CC", "CCC", "CD", "D", "DC", "DCC", "DCCC", "CM" };
            static string[] thousands = { "", "M", "MM", "MMM" };
            static public bool IsRomanNumber(string source) {
                try {
                    return RomanNumberToInt(source) > 0;
                }
                catch {
                    return false;
                }
            }
            /// <summary>
            /// Parses a string containing a roman number.
            /// </summary>
            /// <param name="source">source string</param>
            /// <returns>The integer value of the parsed roman numeral</returns>
            /// <remarks>
            /// Throws an exception on invalid source.
            /// Throws an exception if source is not a valid roman number.
            /// Supports roman numbers from "I" to "MMMCMXCIX" ( 1 to 3999 )
            /// NOTE : "IMMM" is not valid</remarks>
            public static int RomanNumberToInt(string source) {
                if (String.IsNullOrWhiteSpace(source)) {
                    throw new ArgumentNullException();
                }
                int total = 0;
                string buffer = source;
                // parse the last four characters in the string
                // each time we check the buffer against a number array,
                // starting from units up to thousands
                // we quit as soon as there are no remaing characters to parse
                total += RipOff(buffer, units, out buffer);
                if (buffer != null) {
                    total += (RipOff(buffer, tens, out buffer)) * 10;
                }
                if (buffer != null) {
                    total += (RipOff(buffer, hundreds, out buffer)) * 100;
                }
                if (buffer != null) {
                    total += (RipOff(buffer, thousands, out buffer)) * 1000;
                }
                // after parsing for thousands, if there is any character left, this is not a valid roman number
                if (buffer != null) {
                    throw new ArgumentException(String.Format("{0} is not a valid roman number", buffer));
                }
                return total;
            }
            /// <summary>
            /// Given a string, takes the four characters on the right,
            /// search an element in the numbers array and returns the remaing characters.
            /// </summary>
            /// <param name="source">source string to parse</param>
            /// <param name="numbers">array of roman numerals</param>
            /// <param name="left">remaining characters on the left</param>
            /// <returns>If it finds a roman numeral returns its integer value; otherwise returns zero</returns>
            public static int RipOff(string source, string[] numbers, out string left) {
                int result = 0;
                string buffer = null;
                // we take the last four characters : this is the length of the longest numeral in our arrays
                // ("VIII", "LXXX", "DCCC")
                // or all if source length is 4 or less
                if (source.Length > 4) {
                    buffer = source.Substring(source.Length - 4);
                    left = source.Substring(0, source.Length - 4);
                }
                else {
                    buffer = source;
                    left = null;
                }
                // see if buffer exists in the numbers array 
                // if it does not, skip the first character and try again
                // until buffer contains only one character
                // append the skipped character to the left arguments
                while (!numbers.Contains(buffer)) {
                    if (buffer.Length == 1) {
                        left = source; // failed
                        break;
                    }
                    else {
                        left += buffer.Substring(0, 1);
                        buffer = buffer.Substring(1);
                    }
                }
                if (buffer.Length > 0) {
                    if (numbers.Contains(buffer)) {
                        result = Array.IndexOf(numbers, buffer);
                    }
                }
                return result;
            }
        }
    }
