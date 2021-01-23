    [TestMethod]
    public void Container_Always_ContainsNoDiagnosticWarnings()
    {
        // Arrange
        var container = Bootstrapper.GetInitializedContainer();
        container.Verify();
        // Assert
        var results = Analyzer.Analyze(container);
        Assert.IsFalse(results.Any(), Environment.NewLine +
            string.Join(Environment.NewLine,
                from result in results
                select result.Description));
    }
