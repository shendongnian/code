    public static class XmlExtensions {
      public static string SafeValue(this XAttribute attribute) {
        var value = attribute == null ? null : attribute.Value;
        return value;
      }
    }
