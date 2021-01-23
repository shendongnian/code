    public sealed class NewWhitespaceAnalyzer : Analyzer
    {
        public override TokenStream TokenStream(System.String fieldName, System.IO.TextReader reader)
        {
            return new LowerCaseFilter(new WhitespaceTokenizer(reader));
        }
        public override TokenStream ReusableTokenStream(System.String fieldName, System.IO.TextReader reader)
        {
            SavedStreams streams = (SavedStreams) GetPreviousTokenStream();
			if (streams == null)
			{
				streams = new SavedStreams();
				SetPreviousTokenStream(streams);
				streams.tokenStream = new WhiteSpaceTokenizer(reader);
				streams.filteredTokenStream = new LowerCaseFilter(streams.tokenStream);
			}
			else
			{
				streams.tokenStream.Reset(reader);
			}
            return streams.filteredTokenStream;
        }
    }
