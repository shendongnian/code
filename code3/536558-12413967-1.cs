    class X
    { 
        private string s;
        public void Y()
        {
            Console.WriteLine(s == default(string));  // this evaluates to true
        }
    }
