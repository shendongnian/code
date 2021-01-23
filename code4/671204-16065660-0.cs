    static void NormalizeFilenamesInDescription(string message) {
        // Find all the "letter colon backslash", indicating filenames.
        var matches = Regex.Matches(message, @"\w:\\", RegexOptions.Compiled);
        // Go backwards. Useful if you need to replace stuff in the message
        foreach (var idx in matches.Cast<Match>().Select(m => m.idx).Reverse()) {
            int length = 3;
            var potentialPath = message.Substring(idx, length);
            var lastGoodPath = potentialPath;
            // Eat "\" until we get an invalid path
            while (Directory.Exists(potentialPath)) {
                lastGoodPath = potentialPath;
                while (idx+length < message.Length && message[idx+length] != '\\')
                    length++;
                length++; // Include the trailing backslash
                if (idx + length >= message.Length)
                    length = (message.Length - idx) - 1;
                potentialPath = message.Substring(idx, length);
            }
            potentialPath = message.Substring(idx);
            
            // Iterate over the files in directory we found until we get a match
            foreach (var file in Directory.EnumerateFiles(lastGoodPath)
                                          .OrderByDescending(s => s.Length)) {
                if (!potentialPath.StartsWith(file))
                    continue;
                // 'file' contains a valid file name
                break;
            }
        }
    }
