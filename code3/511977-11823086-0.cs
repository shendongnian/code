    public class ParseHelper
    {
        public char TextDelimiter { get; set; }
        public char TextQualifier { get; set; }
        public char EscapeCharacter { get; set; }
        public List<string> Parse(string str, bool keepTextQualifiers = false)
        {
            List<string> returnedValues = new List<string>();
            bool inQualifiers = false;
            string currentWord = "";
            for (int i = 0; i < str.Length; i++)
            {
                //Looking for EscapeCharacter.
                if (str[i] == EscapeCharacter)
                {
                    i++;
                    currentWord += str[i];
                    continue;
                }
                //Looking for TextQualifier.
                if (str[i] == TextQualifier)
                {
                    if (keepTextQualifiers)
                        currentWord += TextQualifier;
                    inQualifiers = !inQualifiers;
                    continue;
                }
                //Looking for TextDelimiter.
                if (str[i] == TextDelimiter && !inQualifiers)
                {
                    returnedValues.Add(currentWord);
                    currentWord = "";
                    continue;
                }
                currentWord += str[i];
            }
            if (inQualifiers)
                throw new FormatException("The input string, 'str', is not properly formated.");
            returnedValues.Add(currentWord);
            currentWord = "";
            return returnedValues;
        }
    }
