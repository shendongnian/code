    public static class Extensions
    {
        public static string ReplaceExact(this string value, 
                                          string oldWord, string newWord)
        {
            Regex r = new Regex(string.Format(@"\b{0}\b", oldWord));
            return r.Replace(value, newWord);
        }
    }
