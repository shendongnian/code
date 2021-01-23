    private bool eventOccurred;
    private void DataParsed(object sender, ParsedArgs e)
    {
       eventOccurred = e.Id == "2F7PY1662477";
    }
    
    [Test]
    public void TestDocParse()
    {
        _parser.ParseFixture(TextToParse);
        Assert.IsTrue(eventOccurred);
    }
