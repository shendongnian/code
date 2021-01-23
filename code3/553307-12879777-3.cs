    /// <summary>
    /// Performs tokenization of a collection of non-tokenized data parts with a specific pattern
    /// </summary>
    /// <param name="tokenKind">The name to give the located tokens</param>
    /// <param name="pattern">The pattern to use to match the tokens</param>
    /// <param name="untokenizedParts">The portions of the input that have yet to be tokenized (organized as text vs. position in source)</param>
    /// <returns>The set of tokens matching the given pattern located in the untokenized portions of the input, <paramref name="untokenizedParts"/> is updated as a result of this call</returns>
    static IEnumerable<Token> Tokenize(string tokenKind, string pattern, ref KeyValuePair<string, int>[] untokenizedParts)
    {
        //Do a bit of setup
        var resultParts = new List<KeyValuePair<string, int>>();
        var resultTokens = new List<Token>();
        var regex = new Regex(pattern);
        //Look through all of our currently untokenized data
        foreach (var part in untokenizedParts)
        {
            //Find all of our available matches
            var matches = regex.Matches(part.Key).OfType<Match>().ToList();
            //If we don't have any, keep the data as untokenized and move to the next chunk
            if (matches.Count == 0)
            {
                resultParts.Add(part);
                continue;
            }
            //Store the untokenized data in a working copy and save the absolute index it reported itself at in the source file
            var workingPart = part.Key;
            var index = part.Value;
            //Look through each of the matches that were found within this untokenized segment
            foreach (var match in matches)
            {
                //Calculate the effective start of the match within the working copy of the data
                var effectiveStart = match.Index - (part.Key.Length - workingPart.Length);
                resultTokens.Add(Token.Create(tokenKind, match, part.Value));
                //If we didn't match at the beginning, save off the first portion to the set of untokenized data we'll give back
                if (effectiveStart > 0)
                {
                    var value = workingPart.Substring(0, effectiveStart);
                    resultParts.Add(new KeyValuePair<string, int>(value, index));
                }
                //Get rid of the portion of the working copy we've already used
                if (match.Index + match.Length < part.Key.Length)
                {
                    workingPart = workingPart.Substring(effectiveStart + match.Length);
                }
                else
                {
                    workingPart = string.Empty;
                }
                //Update the current absolute index in the source file we're reporting to be at
                index += effectiveStart + match.Length;
            }
            //If we've got remaining data in the working copy, add it back to the untokenized data
            if (!string.IsNullOrEmpty(workingPart))
            {
                resultParts.Add(new KeyValuePair<string, int>(workingPart, index));
            }
        }
        //Update the untokenized data to contain what we couldn't process with this pattern
        untokenizedParts = resultParts.ToArray();
        //Return the tokens we were able to extract
        return resultTokens;
    }
