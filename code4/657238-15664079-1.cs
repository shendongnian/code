    public class StringStuff
    {
        private const char cr = '\x0d'; // segment terminator
        private const char lf = '\x0a'; // data element separator
        private const char rs = '\x1e'; // record separator
        private const char sp = '\x20'; // white space
        
        public string BuildString()
        {
            var a = "hello";
            var b = "world";
            var output = a + rs + b
            
            return output;
        }
    }
