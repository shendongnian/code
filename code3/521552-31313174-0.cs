    public static class StringExtender
    {
        public static string MultipleReplace(this string text, Dictionary<string, string> replacements)
        {
            string retVal = text;
            foreach (string textToReplace in replacements.Keys)
            {
                retVal = retVal.Replace(textToReplace, replacements[textToReplace]);
            }
            return retVal;
        }
    }
