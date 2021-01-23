    class PickyClass {
      public class RequiredKeys
      {
        public const string Length = "length";
        public const string Width = "width";
      }
      /// <summary>
      /// Please note that you must include every const in RequiredKeys in values
      /// </summary>
      public void Setup(Dictionary<string,string> values)
      {
        ...
      }
    }
