    public IEnumerable TestCasesSourcesAllProperties
    {
        get
        {
            yield return new TestCaseData(
                new Tuple<string, string>[] { 
                    Tuple.Create("First", "foo"), 
                    Tuple.Create("Second", "bar"), 
                    Tuple.Create("Third", "boo") } as object)
                        .SetDescription("Test all properties using Constraint expression");
        }
    }
