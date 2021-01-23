    // get test parameters from TestCasesSourcesAllProperties
    [TestCaseSource("TestCasesSourcesAllProperties")]
    public void ClassUnderTest_CheckAllProperty_ExpectValues(Tuple<string, string>[] propertiesNamesWithValues)
    {
        // Arrange
        ClassUnderTest cut = null;
        
        // Act: perform actual test, here is only assignment
        cut = new ClassUnderTest { First =  "foo", Second = "bar",  Third  = "boo" };
        
        // Assert
        // check that class-under-test is not null
        NUnit.Framework.Constraints.Constraint expression = Is.Not.Null;
        
        foreach(var property in propertiesNamesWithValues)
        {
            // add constraint for every property one by one
            expression = expression.And.Property(property.Item1).EqualTo(property.Item2);
        }
        
        Assert.That(cut, expression);
    }
