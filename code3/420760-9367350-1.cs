    public string ReplaceChar(string sourceString, char newChar, int charIndex)
        {
            try
            {
                // if the sourceString exists
                if (!String.IsNullOrEmpty(sourceString))
                {
                    // verify the lenght is in range
                    if (charIndex < sourceString.Length)
                    {
                        // Get the oldChar
                        char oldChar = sourceString[charIndex];
                        // Replace out the char  ***WARNING - THIS CODE IS WRONG - it replaces ALL occurrences of oldChar in string!!!***
                        sourceString.Replace(oldChar, newChar);
                    }
                }
            }
            catch (Exception error)
            {
                // for debugging only
                string err = error.ToString();
            }
            // return value
            return sourceString;
        }
