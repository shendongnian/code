    private bool Contains(string source, string given)
    {
        return ExtractValidPhrases(source).Any(p => RegexMatch(p, given));
    }
    private bool RegexMatch(string phrase, string given)
    {
        return Regex.IsMatch(phrase, string.Format(@"\b{0}\b", given), RegexOptions.IgnoreCase);
    }
    private IEnumerable<string> ExtractValidPhrases(string source)
    {
        bool valid = false;
        var parentheses = new Stack<char>();
        var phrase = new StringBuilder();
        for(int i = 0; i < source.Length; i++)
        {
            if (valid) phrase.Append(source[i]);
            switch (source[i])
            {
                case '~':
                    valid = true;
                    break;
                case ' ':
                    if (valid && parentheses.Count == 0)
                    {
                        yield return phrase.ToString();
                        phrase.Clear();
                    }
                    if (parentheses.Count == 0) valid = false;
                    break;
                case '(':
                    if (valid)
                    {
                        parentheses.Push('(');
                    }
                    break;
                case ')':
                    if (valid)
                    {
                        parentheses.Pop();
                    }
                    break;
            }
        }
        if (valid) yield return phrase.ToString();
    }
    // NUnit tests
    [Test]
    [TestCase("Homo Sapiens", true)]
    [TestCase("human", true)]
    [TestCase("woman", true)]
    [TestCase("man", false)]
    public void X(string given, bool shouldBeFound)
    {
        const string mainString = @"~(Homo Sapiens means (human being)) or man or ~woman";
            
        Assert.AreEqual(shouldBeFound, Contains(mainString, given));
    }
    [Test]
    public void Y()
    {
        const string mainString = @"~(Homo Sapiens means (human being)) or man or ~woman";
        var checkList = new List<string> {"homo sapiens", "human", "man", "woman"};
        var expected = new List<string> { "homo sapiens", "human", "woman" };
        var filtered = checkList.Where(s => Contains(mainString, s));
        CollectionAssert.AreEquivalent(expected, filtered);
    }
