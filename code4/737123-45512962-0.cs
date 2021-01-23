    public class MyClass
    {
      public void MyMethod([CallerFilePath]string callerFilePath = null, [CallerMemberName]string callerMemberName = null)
      {
        var callerTypeName = Path.GetFileNameWithoutExtension(callerFilePath);
        Console.WriteLine(callerTypeName);
        Console.WriteLine(callerMemberName);
      }
    }
