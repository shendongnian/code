     static void Main(string[] args)
     {
         List<string[]> testCases = new List<string[]>();
         testCases.Add(new string[] { "/test", "xx" });
         testCases.Add(new string[] { "/other" });
         foreach (string[] testCase in testCases)
           Program.PerformMain(testCase);
     }
     static void PerformMain(string[] args)
     {
          // clear state of program
          // execute according to args
     }
