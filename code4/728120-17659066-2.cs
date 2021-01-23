    static void Main(string[] args)
    {
        var localInfo = new LocalTestInfo()
        {
            TestId = 1,
            Parameters = new[]
            {
                "Foo", 
                "Bar",
                "Baz"
            }
        };
        TestInfo forMarshalling;
        using (forMarshalling = (TestInfo)localInfo)
        {
            TestAPI(ref forMarshalling);                
        }
    }
