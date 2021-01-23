    string[] l_lines = { 
            "\t\t\tpublic class MyClass",
            "                        {",
            "                                private bool MyMethod(string s)",
            "                                {",
            "        \t        \t\treturn s == \"\";",
            "                                }",
            "\t\t\t}"  
        };
    int l_tabWeight = 8;
    int l_smallestIndentation =
        l_lines.Min
        (
            s => s.ToCharArray()
                  .TakeWhile( c => Char.IsWhiteSpace( c ) )
                  .Select( c => c == '\t' ? l_tabWeight : 1 )
                  .Sum()
        );
    string[] l_result =
        l_lines.Select
        (
            s =>
            {
                int l_whitespaceToRemove = l_smallestIndentation;
                while ( l_whitespaceToRemove > 0 )
                {
                    l_whitespaceToRemove -= s[0] == '\t' ? l_tabWeight : 1;
                    s = s.Substring( 1 );
                }
                return s;
            }
        ).ToArray();
