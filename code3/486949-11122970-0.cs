    public class FooBar()
    {
        private Test(string s)
        {
            // Some functionality
        }
    
        public FooBar(string s)
        {
            Test(s);
        }
    
        public FooBar(int i)
        {
            // Do what you need here
            Test("MyString");
        }    
    }
