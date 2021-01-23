    string[] testArray = new string[] { "test888", "test181", "test890", "test8" };
    Regex regex = new Regex(@"(?<!\d)8\d*");
    foreach (string testString in testArray)
    {
        if (regex.IsMatch(testString))
            Console.WriteLine("\"{0}\" matches: {1}", testString, regex.Match(testString));
        else
            Console.WriteLine("\"{0}\" doesn't match", testString);
    }
