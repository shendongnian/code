    var str = "Black:#00000|Green:#008000|";
    Dictionary<string, string> dict = str.NameValuePairsToDictionary(":", "|");
        /// <summary>
        /// convert a string that consists of Name/Value Pairs to a Dictionary.
        /// Name and Value are separated by a given name/value separator
        /// Pairs are separated by a given pair separator token.
        /// example:
        /// Black:#00000|Green:#008000
        /// </summary>
        /// <param name="nvParis">string of name value pairs</param>
        /// <param name="nvSeparator">string that separates the name and value in a name value pair</param>
        /// <param name="pairSeparator">string that separates the name/value pairs from each other</param>
        /// <returns>Dictionary of Name value pairs as string,string</returns>
    public static class StringHelper
    {
        public static Dictionary<string, string> NameValuePairsToDictionary(this string nvPairs, string nvSeparator, string pairSeparator)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            // default - "\n\r"
            // split name value pairs by separator
            string[] items = nvPairs.Split(pairSeparator.ToCharArray());
            // for each split item, split the name/value pair by 
            // pair separator to add a dictionary item
            foreach (string item in items)
            {
                string[] keyVal = item.Split(nvSeparator.ToCharArray());
                if (keyVal.Length > 1)
                    dict.Add(keyVal[0], keyVal[1]);
            }
            return dict;
        }
    }
