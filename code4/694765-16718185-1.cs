    string[] l_lines = { 
                            "                                         public class MyClass",
                            "                                         {",
                            "                                             private bool MyMethod(string s)",
                            "                                             {",
                            "                                                 return s == \"\";",
                            "                                             }",
                            "                                         }"  
                       };
    int l_smallestIndentation =
        l_lines.Min( s => Regex.Match( s, "^\\s*" ).Value.Length );
    string[] l_result =
        l_lines.Select( s => s.Substring( l_smallestIndentation ) )
               .ToArray();
    foreach ( string l_line in l_result )
        Console.WriteLine( l_line );
