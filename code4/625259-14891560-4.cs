    public class DefaultProfileRegistry : Registry
    {
      public DefaultProfileRegistry()
      {
        // whatever calls needed to initialize this registry
        SetScans(this);                         // scan
        SetSetterInjection(this);               // DI
        Profile("DefaultProfile", SetDefaults); // even some common defaults
      }
