    public class FooBar()
    {
        public FooBar(string s)
        {
            this.Initialize(s);
        }
    
        public FooBar(int i)
        {
            this.Initialize("My String");
        }
    
        private void Initialize(string s) {
            // Do what constructor 1 did
        }
    }
