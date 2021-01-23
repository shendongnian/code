    using System;
    using System.Reflection;
    using System.IO;
    public class MainClass
    {
          public static int Main(string[] args)
          {
               Assembly a = null;
               try
               {
                    a = Assembly.Load("YourLibraryName");
               }
               catch(FileNotFoundException e)
                   {Console.WriteLine(e.Message);}
  
               Type classType = a.GetType("YourLibraryName.ClassName");
               object obj = Activator.CreateInstance(classType);
  
               object[] paramArray = new object[1];    
               paramArray[0] = new SortledList<DateTime, double>();
               MethodInfo mi = classType.GetMethod("ComputeMeanPosition");
               mi.Invoke(obj, paramArray);
               return 0;
           }
     }
