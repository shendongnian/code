    public class Restartability {
      private readonly string _sourceFile;
      public Restartability(string sourceFile) {
        _sourceFile = sourceFile;
      }
      public string SourceFile {
        get { return _sourceFile; }
      }  
    }
