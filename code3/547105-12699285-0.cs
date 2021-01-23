    public class MasterClass {
    
      private Dictionary<string, Hook> _dict;
    
      public Hook<T> AddHook<T>(string name, T value){
        Hook<T> hook = new Hook<T>(value);
        _dict.Add(name, hook);
        return hook;
      }
    
      public void receiveData(string key, string value) {
        Hook hook;
        if (_dict.TryGetValue(key, out hook)) {
          if (hook._type == typeof(string)) {
            (hook as Hook<string>).Value = value;
          } else if (hook._type == typeof(int)) {
            (hook as Hook<int>).Value = Int32.Parse(value);
          } else {
            throw new NotImplementedException(); // type not found
          }
        } else {
          throw new NotImplementedException(); // name not found
        }
      }
    
    }
    
    public abstract class Hook {
      internal Type _type;
      internal Hook(Type type) {
        _type = type;
      }
    }
    
    public class Hook<T> : Hook {
      public T Value { get; set; }
      public Hook(T value) : base(typeof(T)){
        Value = value;
      }
    }
