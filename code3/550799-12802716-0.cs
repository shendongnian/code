    static class TypeHelper
    {
      public static readonly IList<string> BuiltInTypeNames;
      static TypeHelper()
      {
        Type[] allBuiltInTypes = { typeof(string), typeof(int), typeof(decimal), }; // add whatever types you consider "built-in".
        BuiltInTypeNames = allBuiltInTypes.Select(t => t.FullName).ToList().AsReadOnly();
      }
    }
