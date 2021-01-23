    class Class1
    {
      public Class2Instance{get;set;} 
      public Class1()
      {
        Class2Instance =new Class2();     
      }
    }
    
    class Class2
    {
      public string Greeting = "Hello";
    }
    //////
    var c = new Class1();
    Console.WriteLine(c.Class2Instance.Greeting);
 
