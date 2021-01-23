    public class MyAnalyzer : Analyzer
    {
        public override TokenStream TokenStream(string fieldName, TextReader reader)
        {    	
    		return new ShingleFilter(new LowerCaseFilter(new StandardTokenizer(Lucene.Net.Util.Version.LUCENE_29, reader)), 6);
    	}
    }
