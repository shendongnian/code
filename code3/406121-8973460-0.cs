    public string UpperCaseFirstLetter(string YourLowerCaseWord)
    {
        if (string.IsNullOrEmpty(YourLowerCaseWord))
            return string.Empty;
        return char.ToUpper(YourLowerCaseWord[0]) + YourLowerCaseWord.Substring(1);
    }
