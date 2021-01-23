    public class CaseInsensitiveWhitespaceAnalyzer : Analyzer
    {
        /// <summary>
        /// </summary>
        public override TokenStream TokenStream(string fieldName, TextReader reader)
        {
            TokenStream t = null;
            t = new WhitespaceTokenizer(reader);
            t = new LowerCaseFilter(t);
            return t;
        }
    }
