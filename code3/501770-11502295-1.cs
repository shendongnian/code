    var allowedPatterns = new[] {"^Military \\d{3}\\w{1} [Test|Test2]*$"};
    foreach (var pattern in allowedPatterns) {
        if (System.Text.RegularExpressions.Regex.IsMatch(testString, pattern)) {
            return TestType.Mil;
        }
    }
    allowedPatterns = ... // similar code for IEEE.
