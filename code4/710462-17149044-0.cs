    namespace YourNameSpace
    {
    
        public static class Magic
        {
            public static SelectList GenerateASelectListFor()
            {
                // your code here obviously....
                return new SelectList(new Dictionary<string, string> { { "Foo", "Barr" }, { "Car", "Dog" } });
            }
        }
    }
