    class PickyClass {
      public static readonly string[] RequiredKeys = new[] {"length", "width"};
      /// <summary>
      /// Please note that you must include at least RequiredKeys in values
      /// </summary>
      public void Setup(Dictionary<string,string> values)
      {
        ...
      }
    }
