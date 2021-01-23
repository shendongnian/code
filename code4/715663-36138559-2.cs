    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    public class B
    {
        public int Three { get; set; }
        private string DebuggerDisplay => $"Three = {Three}";
    }
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    public class A
    {
        public int One { get; set; }
        public B Two { get; set; }
        private string DebuggerDisplay => $"One = {One}, two = {Two.ReadDebuggerDisplay()}";
    }
