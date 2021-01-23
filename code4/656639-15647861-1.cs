    public static string RemoveSpecialCharacters(string specialCharacters)
    {
        Regex regex = new Regex("(?:[^a-z0-9 ]|(?<=['\"])s)", RegexOptions.IgnoreCase |  RegexOptions.CultureInvariant | RegexOptions.Compiled);
        return regex.Replace(specialCharacters, String.Empty);
    }
