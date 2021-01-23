    [DebuggerDisplay(@"Three = {Three}")]
    public class B
    {
        public int Three { get; set; }
    
        public override string ToString()
        {
            if (Debugger.IsAttached)
            {
                return string.Format(@"Three = {0}", Three);
            }
            else
            {
                return base.ToString();
            }
        }
    }
