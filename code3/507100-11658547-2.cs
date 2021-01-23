    class Program
    {
      static int Main(string[] args)
      {
        try
        {
          return AsyncContext.RunTask(() => MainAsync(args)).Result;
        }
        catch (Exception ex)
        {
          Console.Error.WriteLine(ex);
          return -1;
        }
      }
 
      static async Task<int> MainAsync(string[] args)
      {
        ...
      }
    }
