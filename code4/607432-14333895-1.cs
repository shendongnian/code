    [Test, Sequential]
    public void Tests([Values("First", "Second", "Third")] string propertyName,
                      [Values("hello", "again", "you")] string expected)
    {
        var obj = new SomeClass 
            { First = "hello", Second = "again", Third = "you" };
        var actual = InvokePropertyExpression<string>(obj, propertyName);
        Assert.AreEqual(expected, actual);
    }
