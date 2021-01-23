    public partial class StructureMapFactoryProvider : IFactoryProvider
    {
      private static readonly IContainer Special;
    
      static StructureMapFactoryProvider()
      {
        // 1) the default registry container
        ObjectFactory.Initialize(x =>
        {
          x.UseDefaultStructureMapConfigFile = false;
          // Defaults
          x.IncludeRegistry<DefaultProfileRegistry>();
        });
        ObjectFactory.Container.SetDefaultsToProfile("DefaultProfile");
    
        // 2) and now register the other(s)
    
        Special  = new StructureMap.Container(new SpecialProfileRegistry());
        Special.SetDefaultsToProfile("Special");
        }
