    public class MyAnalyzer : Analyzer
    {
        public override TokenStream TokenStream(string fieldName, TextReader reader)
        {
            return new PorterStemFilter(new StandardTokenizer(reader));
        }
    }
