    Unhandled Exception: System.TypeInitializationException: The type initializer for
    'ConsoleApplication1.Program' threw an exception. ---> System.ArgumentException:
     parsing "(public|private)? ?(static)? ?(?<type> String|void|int|Double)(\[?]?
     (?<functionName> [a-z_]+)(?<params> [^]+)" - Not enough )'s.
       at System.Text.RegularExpressions.RegexParser.ScanRegex()
       at System.Text.RegularExpressions.RegexParser.Parse(String re, RegexOptions op)
       at System.Text.RegularExpressions.Regex..ctor(String pattern, RegexOptions options, TimeSpan matchTimeout, Boolean useCache)
       at System.Text.RegularExpressions.Regex..ctor(String pattern)
       at ConsoleApplication1.Program..cctor()
       --- End of inner exception stack trace ---
       at ConsoleApplication1.Program.Main(String[] args)
