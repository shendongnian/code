    public class IronRubyErrors : ErrorListener
    {
        public string Message { get; set; }
        public int ErrorCode { get; set; }
        public Severity sev { get; set; }
        public SourceSpan Span { get; set; }
        public override void ErrorReported(ScriptSource source, string message, Microsoft.Scripting.SourceSpan span, int errorCode, Microsoft.Scripting.Severity severity)
        {
            Message = message;
            ErrorCode = errorCode;
            sev = severity;
            Span = span;
        }
    }
