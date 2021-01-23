    int foundInThisFile;
    string regExPattern = FindText;
    System.Text.RegularExpressions.Regex regSearch = null;
    
    if (IgnoreCase)
        regSearch = new System.Text.RegularExpressions.Regex(regExPattern, System.Text.RegularExpressions.RegexOptions.IgnoreCase | System.Text.RegularExpressions.RegexOptions.Multiline);
    else
        regSearch = new System.Text.RegularExpressions.Regex(regExPattern, System.Text.RegularExpressions.RegexOptions.Multiline);
    
                System.Text.RegularExpressions.MatchCollection regExMatches = regSearch.Matches(reader.ReadToEnd());
    
                if (reader != null)
                {
                    reader.Dispose();
                    reader = null;
                }
    
                found += regExMatches.Count;
                TotalMatches(new CountEventArgs(found));
    
                foundInThisFile = regExMatches.Count;
                MatchesInThisFile(new CountEventArgs(foundInThisFile));
    
                if (regExMatches.Count > 0)
                {
                    foreach (System.Text.RegularExpressions.Match match in regExMatches)
                    {
                        // The first "group" is going to be the entire regex match, any other "group" is going to be the %1, %2 values that are returned
                        // Index is the character position in the entire document
                        if (match.Groups.Count > 1)
                        {
                            // This means the user wants to see the grouping results
                            string[] groupsArray = new string[match.Groups.Count - 1];
    
                            for (int counter = 1; counter < match.Groups.Count; counter++)
                                groupsArray[counter - 1] = match.Groups[counter].Value;
    
                            int lineNumber = 0;
                            string actualLine = String.Empty;
    
                            GetLineNumberAndLine(localPath, match.Groups[0].Index, out lineNumber, out actualLine);
    
                            AddToSearchResults(localPath, lineNumber, actualLine, groupsArray);
    
                            NewSearchResult(new SearchResultArgs(new FindReplaceItem(localPath, lineNumber, actualLine, ConvertGroupsArrayToString(groupsArray))));
                        }
                        else
                        {
                            int lineNumber = 0;
                            string actualLine = String.Empty;
    
                            GetLineNumberAndLine(localPath, match.Groups[0].Index, out lineNumber, out actualLine);
    
                            AddToSearchResults(localPath, lineNumber, actualLine);
    
                            NewSearchResult(new SearchResultArgs(new FindReplaceItem(localPath, lineNumber, actualLine)));
                        }
                    }
                }
