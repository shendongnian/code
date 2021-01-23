    public static class AttributeExtension
    {
      public static bool HasAttribute(this PropertyInfo target, Type attribType)
      {
        var attribs = target.GetCustomAttributes(attribType, false);
        return attribs.Length > 0;
      }
    }
