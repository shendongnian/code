    [TestMethod]
    public void AssignmentTest()
    {
        var testObj = new TestRefClass() { TestInt = 0 };
        TestAssignmentMethod(testObj);
        Assert.IsTrue(testObj.TestInt == 1);
    }
