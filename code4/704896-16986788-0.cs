    class MyClass
    {
    }
    class MyClass2 : MyClass
    {
       public MyClass2(MyClass original)
       {
       }
    }
    bool UpdateMyClass(ref MyClass input)
    {
       bool success = false;
       if (input != null)
       {
           //Generate a new object with some additional functionality.
           input = new MyClassWithSuperPowers(input);
           success = true;
       }
       return success;
    }
