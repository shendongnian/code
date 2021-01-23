	[Flags]
	enum eParseState: byte
	{
		bold = 1,
		italic = 2,
	}
	// Sample input: "<txt>This is <i>some</i> text. <b>This value is <i>bold</i>.</b> This one is not.</txt>"
	static void parseRichText( TextBlock tb, string xml )
	{
		tb.Inlines.Clear();
		XmlReader reader = XmlReader.Create( new StringReader( xml ), new XmlReaderSettings() { ConformanceLevel=ConformanceLevel.Fragment } );
		eParseState state = 0;
		var names = new Dictionary<string, eParseState>()
		{
			{ "b", eParseState.bold },
			{ "i", eParseState.italic },
		};
		Action<bool> actElement = ( bool isOpening ) =>
		{
			string name = reader.Name.ToLower();
			eParseState flag;
			if( !names.TryGetValue( name, out flag ) ) return;
			if( isOpening )
				state |= flag;
			else
				state &= ( ~flag );
		};
		while( reader.Read() )
		{
			switch( reader.NodeType )
			{
				case XmlNodeType.Element:
					actElement( true );
					break;
				case XmlNodeType.EndElement:
					actElement( false );
					break;
				case XmlNodeType.Text:
					var run = new Run() { Text = reader.Value };
					if( 0 != ( state & eParseState.bold ) ) run.FontWeight = FontWeights.Bold;
					if( 0 != ( state & eParseState.italic ) ) run.FontStyle = FontStyles.Italic;
					tb.Inlines.Add( run );
					break;
			}
		}
	}
