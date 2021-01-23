    class A
    {
        private string someString;
        public A(string someString)
        {
            this.someString = someString;
        }
        public string SomeString
        {
            get { return someString; }
        }
        public void DoSomething()
        {
            someString = someString + "_abc";
        }
    }
    var sampleString = "Hello, world!";
    var a = new A(sampleString);
    Console.WriteLine(a.SomeString == sampleString); // prints 'true'
    a.DoSomething();
    Console.WriteLine(a.SomeString == sampleString); // prints 'false'
    Console.WriteLine(sampleString); // prints 'Hello, world!'
    Console.WriteLine(a.SomeString); // prints 'Hello, world!_abc'
