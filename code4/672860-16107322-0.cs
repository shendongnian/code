    public static class CommandLineHelper
    {
      public static string GetCommandLine()
      {
       #if DEBUG
         return "my command line string";
       #else
         return Enviroment.CommandLine;
       #endif
      }
    }
