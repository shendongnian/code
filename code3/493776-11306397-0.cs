    void fun(ref int a)
    {
       // forgot to use a. our object is already eligible for GC!
       for(int i = 0; i < 10; i++)
       {
          Console.WriteLine(i);
       }
    }
    void fun2(ref int a)
    {       
       for(int i = 0; i < 10; i++)
       {
          Console.WriteLine(a);
       }
       // GC has to wait until a is no longer in use. now our object is eligible for GC.
    }
    void fun3(ref int a)
    {
       // can't gc yet. a is still being used.
       int b = a;
       // b has a copy of the value in a so now our object is eligible for GC.
       for(int i = 0; i < 10; i++)
       {
          Console.WriteLine(b);
       }
    }
