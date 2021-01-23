    [DebuggerDisplay("{DebugValue,nq}")]
    public class FileWrapper {
      public string FileName     { get; set; }
      public bool   IsTempFile   { get; set; }
      public string TempFileName { get; set; }
      private string DebugValue {
        get {
          var text = string.Format("{0}: FileName={1}", this.GetType(), this.FileName);
          if (this.IsTempFile)
            text += string.Format(", TempFileName={0}", this.TempFileName);
          return text;
        }
      }
    }
