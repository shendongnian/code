    public enum TestType
    {
        Unknown,
        Mil,
        IEEE
    }
    
    class TestEnumParseRule
    {
        public string[] AllowedPatterns { get; set; }
        public TestType Result { get; set; }
    }
    private static TestType GetEnumType(string test, List<TestEnumParseRule> rules)
    {
        var result = TestType.Unknown;
        var any = rules.FirstOrDefault((x => x.AllowedPatterns.Any(y => System.Text.RegularExpressions.Regex.IsMatch(test, y))));
        if (any != null)
            result = any.Result;
        return result;
    }
    var objects = new List<TestEnumParseRule>
                      {
                          new TestEnumParseRule() {AllowedPatterns = new[] {"^Military \\d{3}\\w{1} [Test|Test2]+$"}, Result = TestType.Mil},
                          new TestEnumParseRule() {AllowedPatterns = new[] {"^IEEE \\d{3}\\w{1} [Test|Test2]+$"}, Result = TestType.IEEE}
                      };
    var testString1 = "Military 888d Test";
    var testString2 = "Miltiary 833d Spiral";
    var result = GetEnumType(testString1, objects);
    Console.WriteLine(result); // Mil
    result = GetEnumType(testString2, objects);
    Console.WriteLine(result); // Unknown
