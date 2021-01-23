    public class A : ICommonStuff
    {
        public int AInt { get; set; }
        public string AString { get; set; }
        public int CommonInt
        {
            get { return this.AInt; }
        }
        public string CommonString
        {
            get { return this.AString; }
        }
    }
    public class B : ICommonStuff
    {
        public int BInt { get; set; }
        public string BString { get; set; }
        public int CommonInt
        {
            get { return this.BInt; }
        }
        public string CommonString
        {
            get { return this.BString; }
        }
    }
    ... (same for C)
