    class aaa
    {
      public string a(int i)
      {
        ...
      }
      public string b (int i)
      {
        ...
      }
    }
    static class ExtensionContainer
    {
      public static void x(this aaa myclass)
      {
        string str = myclass.a(5);
      }
    }
