    class Test
    {
        DefaultableValue<string> AString { get; set; }
    
        public Test(string initialValue)
        {
            this.AString = new DefaultableValue<string>(initialValue, 
                (value) => string.IsNullOrWhiteSpace(value),
                () => string.Empty);
        }
    }
    ....
    var test = new Test(null);
    var someString = test.AString; // = "" not null
