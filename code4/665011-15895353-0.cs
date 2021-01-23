    class Program
    {
       [DllImport(@"c:\MethodNameLibrary.dll")]
       private static extern int methodName(int b);
       static void Main(string[] args)
       {
           Console.WriteLine(methodName(3));
       }
    }
