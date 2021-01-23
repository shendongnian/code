    char[] spaces = Properties.Settings.Default.MultiSpaceString.GetCharsByDecimal(new char[] { ';' });
    string stringSpaces = string.Join(string.Empty, spaces);
    //Extension method for getting chars by decimal from our string
    public static char[] GetCharsByDecimal(this string inputString, char[] delimiters)
        {
            int[] charsDecimals = inputString.Split(delimiters, StringSplitOptions.RemoveEmptyEntries).Select(s => int.Parse(s)).ToArray();
            char[] resultChars = new char[charsDecimals.Length];
    
            for (int i = 0; i < charsDecimals.Length; i++)
            {
                resultChars[i] = Convert.ToChar(charsDecimals[i]);
            }
    
            return resultChars;
        }
    //Or safer variant of our extension method
    public static char[] GetCharsByDecimal(this string inputString)
        {
            int[] charsDecimals = Regex.Split(inputString, @"\D+").Select(s => int.Parse(s)).ToArray();
            char[] resultChars = new char[charsDecimals.Length];
    
            for (int i = 0; i < charsDecimals.Length; i++)
            {
                resultChars[i] = Convert.ToChar(charsDecimals[i]);
            }
    
            return resultChars;
        }
