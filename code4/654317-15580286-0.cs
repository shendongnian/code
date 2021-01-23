    internal class PhoneNumber
        {
            private string a;
            private string m;
            private string l;
    
            public PhoneNumber(string a, string m, string l)
            {
                // TODO: Complete member initialization
                this.a = a;
                this.m = m;
                this.l = l;
            }
        }
    class BlockedNumber : PhoneNumber
    {
        public BlockedNumber(string a, string m, string l)
            : base(a, m, l) { }
    }
This code compiles just fine so just like Yuriy stated the issue must be somewhere else.
