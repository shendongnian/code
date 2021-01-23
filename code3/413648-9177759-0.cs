     /// <summary>
     /// Represents possible values returned by the MessageBox function.
     /// </summary>
     public enum MessageBoxResult : uint
     {
         Ok = 1,
         Cancel,
         Abort,
         Retry,
         Ignore,
         Yes,
         No,
         Close,
         Help,
         TryAgain,
         Continue,
         Timeout = 32000
     }
