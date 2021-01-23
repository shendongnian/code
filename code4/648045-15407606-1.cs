    Example
    // cs_operator_typeof.cs
    // Using typeof operator
    using System;
    using System.Reflection;
    
    public class MyClass 
    {
       public int intI;
       public void MyMeth() 
       {
       }
    
       public static void Main() 
       {
          Type t = typeof(MyClass);
    
          // alternatively, you could use
          // MyClass t1 = new MyClass();
          // Type t = t1.GetType();
    
          MethodInfo[] x = t.GetMethods();
          foreach (MethodInfo xtemp in x) 
          {
             Console.WriteLine(xtemp.ToString());
          }
    
          Console.WriteLine();
    
          MemberInfo[] x2 = t.GetMembers();
          foreach (MemberInfo xtemp2 in x2) 
          {
             Console.WriteLine(xtemp2.ToString());
          }
       }
    }
