    public class NewListEntryEventArgs : EventArgs
    {
        private readonly string test;
        public NewListEntryEventArgs(string test)
        {
            this.test = test;
        }
        public string Test
        {
            get { return this.test; }
        }
    }
