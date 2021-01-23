    public class MySingleton : Singleton<MySingleton> {
      protected MySingleton () {} // Protect the constructor!
    
      public string globalVar;
    
      void Awake () {
          Debug.Log("Awoke Singleton Instance: " + gameObject.GetInstanceID());
      }
    }
