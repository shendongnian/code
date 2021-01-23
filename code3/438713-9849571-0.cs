    public class Global {
      private static Global _global = new Global();
      public static Instance { get { return _global; } set { _global = value; } }
      public TheString { get; set; }
    }
