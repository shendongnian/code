    static Dictionary<string, string> testD = new Dictionary<string, string>(StringComparer.CurrentCulture);
    static bool InputExists(string input, out string correctedCaseString)
    {
        correctedCaseString = input;
        if (testD.ContainsKey(input))
        {
            correctedCaseString = testD[input];
            return true;
        }
        return false;
    }
