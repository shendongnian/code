    static void Main( string[] args )
    {
        string l_input =
            "Back <?rh-udv_start name=\"ctrl_btn\" ?><?rh-udv_start name=\"ctrl_btn\"" +
            "   ?>button<?rh-udv_end ?><?rh-udv_end ?> to";
        string[] l_singleTags = { "foo" };
        string[] l_multiTags = { "baz" };
        // Removing the single tags is easy:
        l_input = Regex.Replace( l_input, @"<\?(?<tagname>[-a-z]+_[a-z]+).*?\?>(?=<\?\k<tagname>)", "", RegexOptions.Singleline );
        Console.WriteLine( l_input );
        Console.ReadKey( true );
    }
