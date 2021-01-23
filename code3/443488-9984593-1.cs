    [Test]
    public void ShouldPrint()
    {
        Mock<IPrinter> printer = new Mock<IPrinter>();            
        Report report = new Report(printer.Object);
        report.Text = "foo";
    
        Assert.True(report.TryPrint());
        printer.Verify(p => p.Print("foo"));
    }
    
    [Test]
    public void ShouldNotPrint()
    {
        Mock<IPrinter> printer = new Mock<IPrinter>();
        printer.Setup(p => p.Print(It.IsAny<string>())).Throws<Exception>();
        Report report = new Report(printer.Object);
        report.Text = "foo";
    
        Assert.False(report.TryPrint());
    }
