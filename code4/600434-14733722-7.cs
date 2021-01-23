    private static Regex ComplexTypeRegex = new Regex( @"^\s*(?<TypeName>\w+)\s*\[(?<Properties>([^\[\]]|\\\[|\\\]|(?<!\\)\[(?<Depth>)|(?<!\\)\](?<-Depth>))*(?(Depth)(?!)))\]\s*$" );
    private static Regex PropertyRegex = new Regex( @"(?<PropertyName>\w+)\s*=\s*(?<PropertyValue>([^\[\]]|\\\[|\\\]|(?<!\\)\[(?<Depth>)|(?<!\\)\](?<-Depth>))*?(?(Depth)(?!))(?=$|(?<!\\)\]|,?\s*\w+\s*=))" );
    private static string Input = @"ObjectType [property1=value1,val\=value2  , property2=value2 \[property2\=this is not an object\], property3=AnotherObjectType [property4=some value4]]";
    static void Main( string[] args )
    {
        Console.Write( Process( 0, Input ) );
        Console.WriteLine( "\n\nPress any key..." );
        Console.ReadKey( true );
    }
    private static string Process( int level, string input )
    {
        var l_complexMatch = ComplexTypeRegex.Match( input );
        var l_indent = string.Join( "", Enumerable.Range( 0, level * 3 ).Select( i => " " ).ToArray() );
        var l_output = new StringBuilder();
        l_output.AppendLine( l_indent + l_complexMatch.Groups["TypeName"].Value );
        foreach ( var l_match in PropertyRegex.Matches( l_complexMatch.Groups["Properties"].Value ).Cast<Match>() )
        {
            l_output.Append( l_indent + "@" + l_match.Groups["PropertyName"].Value + " = " );
            var l_value = l_match.Groups["PropertyValue"].Value;
            if ( Regex.IsMatch( l_value, @"(?<!\\)\[" ) )
            {
                l_output.AppendLine();
                l_output.Append( Process( level + 1, l_value ) );
            }
            else
            {
                l_output.AppendLine( "\"" + l_value + "\"" );
            }
        }
        return l_output.ToString();
    }
