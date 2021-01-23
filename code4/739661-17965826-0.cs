        public static string RemoveWhiteSpaces(this string s)
        {
            return string.Join(" ", s.Split(new char[] { ' ' }, 
                   StringSplitOptions.RemoveEmptyEntries));
        }
    myString.RemoveWhiteSpaces();
