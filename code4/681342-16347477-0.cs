    public void TestQuoteSubmission([ValueSource(typeof(FooFactory), "GetFoo")]  Foo x, 
    [ValueSource(typeof(BarFactory), "GetBar")] Bar y)
    {
        //Your test here.
    }
