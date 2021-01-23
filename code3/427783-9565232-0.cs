    public static class MyStaticClass
    {
       public static int MyStaticProperty;
       //no accessors required, as this is never explicitly invoked
       static MyStaticClass() //no parameters either
       {
          MyStaticProperty = 100;
       }
    }
    ....
    //writes: 100
    Console.WriteLine(MyStaticClass.MyStaticProperty);
