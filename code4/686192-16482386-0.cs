    public static string UnCamelCase(this string text)
    {
        /*match any instances of a lower case character followed by an upper case 
         * one, and replace them with the same characters with a space between them*/
        return Regex.Replace(text, "([a-z])([A-Z])", "$1 $2");
    }
