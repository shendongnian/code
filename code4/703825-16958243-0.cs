    static bool IsMatch(string templateString, string input)
    {
        string[] splittedStr = templateString.Split('#');
        string regExString = splittedStr[0];
        for (int i = 1; i < splittedStr.Length; i++)
        {
            regExString += "[\\w\\s]*" + splittedStr[i];
        }
    
        Regex regEx = new Regex(regExString);
        return regEx.IsMatch(input);
    }
