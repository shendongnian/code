    static public class OriginalCommandLine
    {
        // regexes search for strings quoted in single and double quotes.
        static Regex tokenizer = new Regex(@"""(?:\\""(?!\s)|[^""])*""|[^\s]+");
        static Regex unescaper = new Regex(@"\\("")(?!\s|$)");
        static Regex unquoter = new Regex(@"^\s*""|""\s*$");
        static Regex quoteTester = new Regex(@"^\s*""(?:\\""|[^""])*""\s*$");
        static public string[] Parse(string commandLine = null)
        {
            return tokenizer.Matches(commandLine ?? Environment.CommandLine).Cast<Match>()
                .Skip(1).Select(m => unescaper.Replace(m.Value, @"""")).ToArray();
        }
        static public string UnQuote(string text)
        {
            return (IsQuoted(text)) ? unquoter.Replace(text, "") : text;
        }
        static public bool IsQuoted(string text)
        {
            return text != null && quoteTester.Match(text).Success;
        }
    }
