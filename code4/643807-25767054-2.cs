    public static string SplitToLines(this string originalText, char[] splitOnCharacter, int maxStringLength)
        {
            StringBuilder sb = new StringBuilder();
            int index = 0;
    
            while (originalText.Length > index)
            {
                // get the next substring, else the rest of the string if remainder is shorter than `maxStringLength`
                var splitAt = index + maxStringLength <= originalText.Length ?
                    originalText.Substring(index, maxStringLength).LastIndexOfAny(splitOnCharachter) :
                    originalText.Length - index;
    
                // if can't find split location, take `maxStringLength` charachters
                splitAt = (splitAt == -1) ? maxStringLength : splitAt;
    
                // add result to collection & increment index
                sb.AppendLine(originalText.Substring(index, splitAt).Trim());
                index += splitAt;
            }
    
            return sb.ToString();
        }
