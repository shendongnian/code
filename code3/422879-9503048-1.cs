    public sealed class PluginFactory {
      PlugingFactory() { }
     
      public static IAppModule LoadPlugin( string typeName ) {
        Type theType = Type.GetType(typeName);
        return (IAppModule)Activator.CreateInstance(theType);
      }
    }
