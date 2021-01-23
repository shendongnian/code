    class Foo
    {
        public void Method(int i, string s, bool b) { }
        public void Method(string s, bool b) 
        {
            Method(0, s, b); // this can't be done with default parameters
        }
    }
