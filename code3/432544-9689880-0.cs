    public class RegExAttribute : ValidationAttribute
    {
        public string Pattern { get; set; }
        public RegexOptions Options { get; set; }
        public RegExAttribute(string pattern) : this(pattern, RegexOptions.None) { }
        public RegExAttribute(string pattern, RegexOptions options)
        {
            Pattern = pattern;
            Options = options;
        }
        public override bool IsValid(object value)
        {
            return Regex.IsMatch(value.ToString(), Pattern, Options);
        }
    }
