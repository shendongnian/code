    using System;
    using System.Linq;
    using System.IO;
    class MyInvokedClass
    {
      public void MyInvokedMethod(int arg0, double arg1)
      {
        Console.WriteLine("arg1 = {0} arg2 = {1}.", arg0, arg1);
      }
    }
    class Program
    {
      public static void InvokeMethod(string className, string methodName, string fileName)
      {
        string[] contents = File.ReadAllLines(fileName);
        var t = Type.GetType(className);
        var m = t.GetMethod(methodName);
        var parametertypes = m.GetParameters().Select(p => p.ParameterType);
        var parameters = parametertypes.Select((type, index) => Convert.ChangeType(contents[index], type)).ToArray();
        var instance = Activator.CreateInstance(t);
        m.Invoke(instance, parameters);
      }
      static void Main()
      {
        InvokeMethod("MyInvokedClass", "MyInvokedMethod", "params.txt");
        Console.ReadKey(true);
      }
    }
