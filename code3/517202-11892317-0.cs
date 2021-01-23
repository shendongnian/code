    public static class Extensions {
      public static string GetValue(this XElement element) {
        return element == null ? null : element.Value;
      }
    }
