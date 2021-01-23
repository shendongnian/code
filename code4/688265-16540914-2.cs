    /// <summary>
    /// Very basic Command Line Args extracter
    /// <para>Parse command line args for args in the following format:</para>
    /// <para>/argname:argvalue /argname:argvalue ...</para>
    /// </summary>
    public class CommandLineArgs
    {    
        private const string Pattern = @"\/(?<argname>\w+):(?<argvalue>.+)";    
        private readonly Regex _regex = new Regex(
            Pattern,
            RegexOptions.IgnoreCase|RegexOptions.Compiled);
        private readonly Dictionary<String, String> _args = 
            new Dictionary<String, String>();
    
        public CommandLineArgs()
        {
            BuildArgDictionary();
        }
    
        public string this[string key]
        {
            get 
            {
                return _args.ContainsKey(key) ? _args[key] : null;
            }
        }
    
        public bool ContainsKey(string key)
        {
            return _args.ContainsKey(key);
        }
    
        private void BuildArgDictionary()
        {
            var args = Environment.GetCommandLineArgs();
            foreach (var match in args.Select(arg => 
                        _regex.Match(arg)).Where(m => m.Success))
            {
                try
                {
                     _args.Add(
                          match.Groups["argname"].Value,
                          match.Groups["argvalue"].Value);
                }
                // Ignore any duplicate args
                catch (Exception) {}
            }
        }
    }
