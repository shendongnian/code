    public interface IDynamicObject {
      bool TryGetAttribute(string key, out object value);
      void SetAttribute(string key, object value);
      // void RemoveAttribute(string key)
    }
    
    public class DynamicObject: IDynamicObject {
      private readonly Dictionary<string, object> data = new Dictionary<string, object>(StringComparer.Ordinal);
    
      bool IDynamicObject.TryGetAttribute(string key, out object value) {
        return data.TryGet(key, out value);
      }
    
      void IDynamicObject.SetAttribute(string key, object value) {
        data[key] = value;
      }
    }
