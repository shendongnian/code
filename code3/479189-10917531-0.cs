    namespace ExtensionMethods
    {
      public static class MyExtensions
      {
        public static bool MyEqual(this String s1, string s2)
        {
            return s1.Equals(s2, StringComparison.InvariantCultureIgnoreCase);
        }
      }
    }
