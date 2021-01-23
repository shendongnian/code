    public class SrcLoc
    {
        public string sourceFile { get; set; }
        public int lineNumber { get; set; }
        public SrcLoc([CallerFilePath] string sourceFile = "",
                      [CallerLineNumber] int lineNumber = 0)
        {
          this.sourceFile = sourceFile;
          this.lineNumber = lineNumber;
        }
    }
    public class Logger
    {
       public void Log(SrcLoc location,
                    int level = 1,
                    string formatString = "",
                    params object[] parameters)
      {
         string message = String.Format(formatString, parameters);
      }
    }
    public MainTest
    {
        public static void Main()
        {
            string file="filename";
            logger.Log(new SrcLoc(), (int)LogLevel.Debug, "My File: {0}", file);
        }
    }
