    // cs_operator_new.cs
    // The new operator
    using System;
    class NewTest 
    {
       struct MyStruct 
       {
          public int x;
          public int y;
          public MyStruct (int x, int y) 
          {
             this.x = x;
             this.y = y;
          }
       }
    
       class MyClass 
       {
          public string name;
          public int id;
    
          public MyClass () 
          {
          }
    
          public MyClass (int id, string name) 
          {
             this.id = id;
             this.name = name;
          } 
       }
    
       public static void Main() 
       {
          // Create objects using default constructors:
          MyStruct Location1 = new MyStruct();
          MyClass Employee1 = new MyClass();
    
          // Display values:
          Console.WriteLine("Default values:");
          Console.WriteLine("   Struct members: {0}, {1}", 
             Location1.x, Location1.y);
          Console.WriteLine("   Class members: {0}, {1}", 
             Employee1.name, Employee1.id);
    
          // Create objects using parameterized constructors::
          MyStruct Location2 = new MyStruct(10, 20);
          MyClass Employee2 = new MyClass(1234, "John Martin Smith");
    
          // Display values:
          Console.WriteLine("Assigned values:");
          Console.WriteLine("   Struct members: {0}, {1}", 
             Location2.x, Location2.y);
          Console.WriteLine("   Class members: {0}, {1}", 
             Employee2.name, Employee2.id);
       }
    }
