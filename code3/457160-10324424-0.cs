    public class BaseClass
    {
      private BaseClass()
      {
      }
      public static BaseClass Create(string input)
      {
        if (input.Substring(0, 5) == "Something")
          return new DerivedClass();
        return new BaseClass();
      }
    }
