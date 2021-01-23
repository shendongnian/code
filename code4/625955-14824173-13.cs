    public interface IAttributeProxy {
      Attribute[] GetProxiedAttributes();
    }
    public class MyStandardCommandAttribute : Attribute, IAttributeProxy {
      public Attribute[] GetProxiedAttributes() {
        return new Attribute[] {
          new ObfuscationAttribute { Exclude = true },
          new UsedImplicitlyAttribute()
        };
      }
    }
