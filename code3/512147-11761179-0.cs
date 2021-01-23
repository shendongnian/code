    public class Framework {
    
        public IList<CompositionPlugin> CompositionPlugins = new List<CompositionPlugin>();
    
        public CompositionPlugin GetCompositionPlugin(Type ofType)
        {
            using(var writer = System.IO.File.CreateText(@"C:\test.log"))
            {
                writer.WriteLine("ofType: " + ofType.toString());
                foreach (CompositionPlugin plugin in CompositionPlugins)
                {
                    writer.WriteLine("plugin: " + plugin.GetType().toString());
                    if (plugin.GetType().Equals(ofType))
                        return plugin;
                }
            }
    
            throw new ArgumentException("A composition plugin of type " + ofType.FullName + " could not be found");
        }
    }
