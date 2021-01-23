    public class SpecialProfileRegistry : Registry
    {
      public SpecialProfileRegistry()
      {
         DefaultProfileRegistry.SetScans(this); // use part from default
         ...
         Profile("Special", DefaultProfileRegistry.SetDefaults); // common defaults
       }
