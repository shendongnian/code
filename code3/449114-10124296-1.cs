    public void Test()
    {
        // Arrange
        TestableNavigationService testableService = new TestableNavigationService ();
        var classUnderTest = new TestClass(testableService );
        // Act
        classUnderTest.GoToMyPage();
        // Assert
        testableService.Verify("Navigate");
    }
