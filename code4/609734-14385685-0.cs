    static void Main( string[] args )
    {
        string l_input =
            "I want to preserve<?start_foo bar=\"value\" ?> the content\n" +
            "<?start_baz qux=\"value\" ?>Name<?end-baz_qux ?>that is not between weird tags.";
        string[] l_singleTags = { "foo" };
        string[] l_multiTags = { "baz" };
        // Removing the single tags is easy:
        foreach ( var l_singleTag in l_singleTags )
            l_input = Regex.Replace( l_input, @"<\?start_" + Regex.Escape( l_singleTag ) + @"\b.*?\?>", "" );
        // Removing the multi tags is not too bad:
        foreach ( var l_multiTag in l_multiTags )
            l_input = Regex.Replace( l_input, @"<\?start_" + Regex.Escape( l_multiTag ) + @" (?<param>\w+).*?\?>.*?<\?end-" + Regex.Escape( l_multiTag ) + @"_\k<param>.*?\?>", "" );
        Console.WriteLine( l_input );
        Console.ReadKey( true );
    }
