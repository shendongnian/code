    [Test]
    public void ShouldThrowExceptionWhenNoPaperLeft()
    {
        Printer printer = new Printer();
        printer.PagesCount = 0;
    
        Exception ex = Assert.Throws<Exception>(() => printer.Print("foo"));
        Assert.That(ex.Message, Is.EqualTo("Out of paper"));
    }
