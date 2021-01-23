    public void ComplexObjectsAreEqual()
    {
        var first = // ...
        var second = // ...
        AssertComplexObjectsAreEqual(first, second);
    }
    private void AssertComplexObjectsAreEqual(ComplexObject first,
        ComplexObject second)
    {
        Assert.That(first.Property1, Is.EqualTo(second.Property1),
           "Property1 differs: {0} vs {1}", first.Property1, second.Property1); 
        // ...
    }
