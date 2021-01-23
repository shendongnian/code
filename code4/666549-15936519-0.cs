    public static class Extensions {
      private static Char[] a = { 'a', 'b', 'c', 'd', 'e', 'f' };
      private static Char[] b = { 'A', 'B', 'C', 'D', 'E', 'F' };
      private static Char[] c = { '1', '2', '3', '4', '5', '6' };
      public static string MyContain(this string value) {
        Char[] x = value.ToCharArray();
        string result = null;
        if (a.Any(l => x.Contains(l))) {
          result = "low";
        }
        if (b.Any(c => x.Contains(c))) {
          result = String.IsNullOrEmpty(result) ? "cap" : result + "&cap";
        }
        if (c.Any(n => x.Contains(n))) {
          result = String.IsNullOrEmpty(result) ? "num" : result + "&num";
        }
        return result;
      }
    }
