    [ExpectedException(typeof(ParametersParseException))]
    [TestCase(new[] { "param1"}, TestName="SingleParam")]
    [TestCase(new[] { "param1", "param2"}, TestName="TwoParams")]
    [TestCase(new[] { "param1", "param2", "param3", "optParam4", "optParam5"}, "some extra parameter", TestName="SeveralParams")]
    public void Parse_InvalidParametersNumber_ThrowsException(params string[] args)
    {
    	new ParametersParser(args).Parse();
    }
