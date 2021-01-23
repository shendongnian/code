    public static class TestHelper
    {
        const string EnvironmentVariable = "TestDataDirectory";
        static string testDataDir = Environment.GetEnvironmentVariable(EnvironmentVariable);
    
        public static string GetTestFile(string partialPath)
        {
            return Path.Combine(testDataDir, partialPath);
        }
    }
...
    
    [Test]
    public void LexicalTest1()
    {
        var codePath = TestHelper.GetTestFile(@"\EvolutionSamples\sample1.evol");
        //.....
    }
