    [AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = false)]
    public sealed class SourceInfoAttribute : Attribute
    {
        public SourceInfoAttribute([CallerLineNumber]int sourceLineNumber = 0, [CallerFilePath] string sourceFilePath = "")
        {
            SourceLineNumber = sourceLineNumber;
            SourceFilePath = sourceFilePath;
        }
        internal int SourceLineNumber { get; set; }
        internal string SourceFilePath { get; set; }
    }    
