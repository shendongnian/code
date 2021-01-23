    public class AttributeProxyAttribute : Attribute {
      public AttributeProxyAttribute(params Type[] proxiedAttributes) {
        // ...
      }
      // ...
    }
    [AttributeProxy(typeof(ObfuscationAttribute), typeof(UsedImplicitlyAttribute))]
    public class MyStandardCommandAttribute : Attribute {}
