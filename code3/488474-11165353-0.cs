    public class NameAttribute : Attribute {
      public string Name { get; private set; }
      public NameAttribute(string name) {
        Name = name;
      }
    }
    [Name("George")]
    public class Dad { 
      public string Name { 
        get { 
          return NameGetter.For(this.GetType()); 
        }
      }
    }
    [Name("Frank")]
    public class Son : Dad {
    }
    public static class NameGetter {
      public static string For<T>() {
        return For(typeof(T));
      }
      public static string For(Type type) {
        // add error checking ...
        return ((NameAttribute)type.GetCustomAttributes(typeof(NameAttribute), false)[0]).Name;
      }
    }
