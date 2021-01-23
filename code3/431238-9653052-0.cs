    public class PropertyBag : DynamicObject {
      private object _source;
      public PropertyBag(object source) {
        _source = source;
      }
      public object GetProperty(string name) {  
        var type = _source.GetType();
        var property = type.GetProperty(name, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
        return property.GetValue(_source, null);
      }
      public override bool TryGetMember(GetMemberBinder binder, out object result) {
        result = GetProperty(binder.Name);
        return true;
      }
      public override bool TryGetIndex(GetIndexBinder binder, object[] indexes, out object result) {
        result = GetProperty((string)indexes[0]);
        return true;
      }
    }
