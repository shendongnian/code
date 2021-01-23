	[TestCase("John,29","John",29,"")]
	[TestCase(",13","",13,"")]
	public void ParserTest(Sting stringToParse, String expextedName, int expectedAge, String expectedComment)
	{
		IParser _parser = new Parser();
		Person _actual = _parser.Parse(stringToParse);
        Assert.AreEqual(expextedName, _actual.Name, stringToParse + " failed on Name");
        Assert.AreEqual(expextedAge, _actual.Age, stringToParse + " failed on Age");
        Assert.AreEqual(expextedComment, _actual.Comment, stringToParse + " failed on Comment");
	}
