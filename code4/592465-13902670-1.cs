    public void AssertMultipleValues<T>(object actual, params object[] expectedResults)
    {
        Assert.IsInstanceOfType(actual, typeof(T));
        bool isExpectedResult = false;
        foreach (object expectedResult in expectedResults)
        {
            if(actual.Equals(expectedResult))
            {
                isExpectedResult = true;
            }
        }
        Assert.IsTrue(isExpectedResult, "The actual object '{0}' was not found in the expected results", actual);
    }
