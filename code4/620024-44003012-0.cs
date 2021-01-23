        public static List<String> Split(this string myString, char separator, char escapeCharacter)
        {
            int nbEscapeCharactoers = myString.Count(c => c == escapeCharacter);
            if (nbEscapeCharactoers % 2 != 0) // uneven number of escape characters
            {
                int lastIndex = myString.LastIndexOf("" + escapeCharacter, StringComparison.Ordinal);
                myString = myString.Remove(lastIndex, 1); // remove the last escape character
            }
            var result = myString.Split(escapeCharacter)
                                 .Select((element, index) => index % 2 == 0  // If even index
                                                       ? element.Split(new[] { separator }, StringSplitOptions.RemoveEmptyEntries)  // Split the item
                                                       : new string[] { element })  // Keep the entire item
                                 .SelectMany(element => element).ToList();
            return result;
        }
