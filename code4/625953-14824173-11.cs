    public static object[] GetCustomAttributesWithProxied(this Type self, bool inherit) {
      var attributes = self.GetCustomAttributes(inherit);
      return attributes.SelectMany(ExpandProxies).ToArray();
    }
    private static object[] ExpandProxies(object attribute) {
      if (attribute is IAttributeProxy) {
        return ((IAttributeProxy)attribute).GetProxiedAttributes().
          SelectMany(ExpandProxies).ToArray(); // don't create an endless loop with proxies!
      }
      else {
        return new object[] { attribute };
      }
    }
