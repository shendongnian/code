    private string ModifyRegexToAcceptHyphensOfCurrentPage(string regex, int searchedPage)
        {
            var indexesToInsertPossibleHyphenation = GetPossibleHyphenPositions(regex, searchedPage);
            var hyphenationToken = @"(-\s+)?";
            return InsertStringTokenInAllPositions(regex, indexesToInsertPossibleHyphenation, hyphenationToken);
        }
        private static string InsertStringTokenInAllPositions(string sourceString, List<int> insertionIndexes, string insertionToken)
        {
            if (insertionIndexes == null || string.IsNullOrEmpty(insertionToken)) return sourceString;
            var sb = new StringBuilder(sourceString.Length + insertionIndexes.Count * insertionToken.Length);
            var linkedInsertionPositions = new LinkedList<int>(insertionIndexes.Distinct().OrderBy(x => x));
            for (int i = 0; i < sourceString.Length; i++)
            {
                if (!linkedInsertionPositions.Any())
                {
                    sb.Append(sourceString.Substring(i));
                    break;
                }
                if (i == linkedInsertionPositions.First.Value)
                {
                    sb.Append(insertionToken);
                }
                if (i >= linkedInsertionPositions.First.Value)
                {
                    linkedInsertionPositions.RemoveFirst();
                }
                sb.Append(sourceString[i]);
            }
            return sb.ToString();
        }
        private List<int> GetPossibleHyphenPositions(string regex, int searchedPage)
        {
            var originalTextOfThePage = mPagesNotModified[searchedPage];
            var hyphenatedParts = Regex.Matches(originalTextOfThePage, @"\w+\-\s");
            var indexesToInsertPossibleHyphenation = new List<int>();
            //....
            // Aho-Corasick to find all occurences of all 
            //strings in "hyphenatedParts" in the "regex" string
            // ....
            return indexesToInsertPossibleHyphenation;
        }
