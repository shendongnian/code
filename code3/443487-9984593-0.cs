    [Test]
    public void ShouldPrintItself()
    {
       Mock<IPrinter> printer = new Mock<IPrinter>();            
       Report report = new Report(printer.Object);
       report.Text = "foo";
    
       report.Print();
       printer.Verify(p => p.Print("foo"));
    }
