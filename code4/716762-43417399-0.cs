    internal static class ExtensionClass
    {
        public static string ReplaceNthOccurance(this string obj, string find, string replace, int nthOccurance)
        {
            if (nthOccurance > 0)
            {
                MatchCollection matchCollection = Regex.Matches(obj, Regex.Escape(find));
                if (matchCollection.Count >= nthOccurance)
                {
                    Match match = matchCollection[nthOccurance - 1];
                    return obj.Remove(match.Index, match.Length).Insert(match.Index, replace);
                }
            }
            return obj;
        }
    }
