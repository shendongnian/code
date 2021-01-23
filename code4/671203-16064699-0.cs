    static void FindFilenamesInMessage(string message)
    {
        // Find all the "letter colon backslash", indicating filenames.
        var matches = Regex.Matches(message, @"\w:\\", RegexOptions.Compiled);
        int length = message.Length;
        foreach (var index in matches.Cast<Match>().Select(m => m.Index).Reverse())
        {
            length = length - index;
            while (length > 0)
            {
                var subString = message.Substring(index, length);
                if (File.Exists(subString))
                {
                    // subString contains a valid file name
                    ///////////////////////
                    // Payload goes here
                    //////////////////////
                    length = index;
                    break;
                }
                length--;
            }
        }
    }
