    public class Grace
    {
        public Grace() {}
        public string AbsoluteFileName
        {
            get {
                return this.GetType().Assembly.CodeBase;
            }
        }
    }
