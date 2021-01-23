    private static Regex ComplexTypeRegex = new Regex( @"^\s*(?<TypeName>\w+)\s*\[(?<Properties>([^\[\]]|\[(?<Depth>)|\](?<-Depth>))*(?(Depth)(?!)))\]\s*$" );
    private static Regex PropertyRegex = new Regex( @"(?<PropertyName>\w+)\s*=\s*(?<PropertyValue>([^\[\]]|\[(?<Depth>)|\](?<-Depth>))*?(?(Depth)(?!))(?=$|\]|,?\s*\w+\s*=))" );
    private static string Input = "ObjectType [property1=value1, property2=value2, property3=AnotherObjectType [property4=some value4]]";
    static void Main( string[] args )
    {
        Process( 0, Input );
        Console.ReadKey( true );
    }
    private static void Process( int level, string input )
    {
        var l_complexMatch = ComplexTypeRegex.Match( input );
        var l_indent = string.Join( "", Enumerable.Range( 0, level * 3 ).Select( i => " " ).ToArray() );
        Console.WriteLine( l_indent + "Complex Type" );
        Console.WriteLine( l_indent + "============" );
        Console.WriteLine( l_indent + l_complexMatch.Groups["TypeName"].Value );
        foreach ( var l_match in PropertyRegex.Matches( l_complexMatch.Groups["Properties"].Value ).Cast<Match>() )
        {
            Console.Write( l_indent + l_match.Groups["PropertyName"].Value + " = " );
            var l_value = l_match.Groups["PropertyValue"].Value;
            if ( l_value.Contains( "[" ) )
            {
                Console.WriteLine();
                Process( level + 1, l_value );
            }
            else
            {
                Console.WriteLine( l_value );
            }
        }
    }
