    class MyClass
    {
      internal string k;
      internal void Test()
      {
        OtherClass.Method(ref k);
      }
    }
    class OtherClass
    {
      internal static Method(ref string l)
      {
        // do a lot of stuff using l
      }
    }
