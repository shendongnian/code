If you're goal is to get a piece or the whole of the StringBuilder's contents in a String object, you should use its ToString function. But if you aren't yet done creating your string, it's better to treat the StringBuilder as a character array and operate in that way than to create a bunch of strings you don't need.
String operations on a character array can become complicated by localization or encoding, since a string can be encoded in many ways (UTF8 or Unicode, for example), but its characters (System.Char) are meant to be 16-bit UTF16 values.
I've written the following method which returns the index of a string if it exists within the StringBuilder and -1 otherwise. You can use this to create the other common String methods like Contains, StartsWith, and EndsWith. This method is preferable to others because it should handle localization and casing properly, and does not force you to call ToString on the StringBuilder. It creates one garbage value if you specify that case should be ignored, and you can fix this to maximize memory savings by using Char.ToLower instead of precomputing the lower case of the string like I do in the function below. **EDIT:** Also, if you're working with a string encoded in UTF32, you'll have to compare two characters at a time instead of just one.
You're probably better off using ToString unless you're going to be looping, working with large strings, and doing manipulation or formatting.
    public static int IndexOf(this StringBuilder stringBuilder, string str, int startIndex = 0, int? count = null, CultureInfo culture = null, bool ignoreCase = false)
    {
        if (stringBuilder == null)
            throw new ArgumentNullException("stringBuilder");
        // No string to find.
        if (str == null)
            throw new ArgumentNullException("str");
        if (str.Length == 0)
            return -1;
        // Make sure the start index is valid.
        if (startIndex < 0 && startIndex < stringBuilder.Length)
            throw new ArgumentOutOfRangeException("startIndex", startIndex, "The index must refer to a character within the string.");
        // Now that we've validated the parameters, let's figure out how many characters there are to search.
        var maxPositions = stringBuilder.Length - str.Length - startIndex;
        if (maxPositions <= 0) return -1;
        // If a count argument was supplied, make sure it's within range.
        if (count.HasValue && (count <= 0 || count > maxPositions))
            throw new ArgumentOutOfRangeException("count");
        // Ensure that "count" has a value.
        maxPositions = count ?? maxPositions;
        if (count <= 0) return -1;
        // If no culture is specified, use the current culture. This is how the string functions behave but
        // in the case that we're working with a StringBuilder, we probably should default to Ordinal.
        culture = culture ?? CultureInfo.CurrentCulture;
        // If we're ignoring case, we need all the characters to be in culture-specific 
        // lower case for when we compare to the StringBuilder.
        if (ignoreCase) str = str.ToLower(culture);
        // Where the actual work gets done. Iterate through the string one character at a time.
        for (int y = 0, x = startIndex, endIndex = startIndex + maxPositions; x <= endIndex; x++, y = 0)
        {
            // y is set to 0 at the beginning of the loop, and it is increased when we match the characters
            // with the string we're searching for.
            while (y < str.Length && str[y] == (ignoreCase ? Char.ToLower(str[x + y]) : str[x + y]))
                y++;
            // The while loop will stop early if the characters don't match. If it didn't stop
            // early, that means we found a match, so we return the index of where we found the
            // match.
            if (y == str.Length)
                return x;
        }
        // No matches.
        return -1;
    }
The primary reason one generally uses a StringBuilder object rather than concatenating strings is because of the memory overhead you incur since strings are immutable. The performance hit you see when you do excessive string manipulation without using a StringBuilder is often the result of collecting all the garbage strings you created along the way.
