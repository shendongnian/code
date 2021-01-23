    public interface IMyConfig {
      string Var1 { get; }
      string Var2 { get; }
    }
    public class MyConfig : IMyConfig {
      private string _Var1;
      private string _Var2;
      public string Var1 { get { return _Var1; } }
      public string Var2 { get { return _Var2; } }
      private static object s_SyncRoot = new object();
      private static IMyConfig s_Instance;
      private MyConfig() {
        // load _Var1, _Var2 variables from db here
      }
      public static IMyConfig Instance {
        get {
          if (s_Instance != null) {
            return s_Instance;
          }
          lock (s_SyncRoot) {
            s_Instance = new MyConfig();
          }
          return s_Instance;
        }
      }
    }
