    [TestCase("", Result = true)]
    [TestCase(".", Result = true)]
    [TestCase("-.", Result = true)]
    [TestCase("-.1", Result = true)]
    [TestCase("+", Result = true)]
    [TestCase("-", Result = true)]
    [TestCase(".0", Result = true)]
    [TestCase("1.0", Result = true)]
    [TestCase("+1.0", Result = true)]
    [TestCase("-1.0", Result = true)]
    [TestCase("001.0", Result = true)]
    [TestCase(" ", Result = false)]
    [TestCase("..", Result = false)]
    [TestCase("..1", Result = false)]
    [TestCase("1+0", Result = false)]
    [TestCase("1.a", Result = false)]
    [TestCase("1..1", Result = false)]
    [TestCase("a11", Result = false)]
    [SetCulture("en-US")]
    public bool TestIsTextValid(string text)
    {
        bool isValid = TextBoxDoubleValidator.IsValid(text);
        Console.WriteLine("'{0}' is {1}", text, isValid ? "valid" : "not valid");
        return isValid;
    }
