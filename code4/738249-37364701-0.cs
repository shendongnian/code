    [TestCase( 1, 2, "100, 200")]
    [TestCase( 5, 3, "300, 500")]
    public void MyClass_MyOtherMethod(long a, long b, string bunchOfNumbersString)
    {
        var bunchOfNumbers= bunchOfNumbersString.Split(',')
                                                .Select(long.Parse)
                                                .ToArray();
       ...
    }
