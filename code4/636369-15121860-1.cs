    public class ParserFactory : IParserFactory
	{
		private readonly IEnumerable<IParser> parsers;
		
		public ParserFactory(IEnumerable<IParser> parsers)
		{
			this.parsers = parsers;
		}
		
		public IParser CreateParser(string someInput)
		{
			foreach (var parser in this.parsers)
			{
				if (parser.CanParse(someInput))
				{
					return parser;
				}
			}
		}
	}
