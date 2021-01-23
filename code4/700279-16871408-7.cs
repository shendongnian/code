    public class CustomAssembliesResolver
        : DefaultAssembliesResolver
    {
        private Assembly[] plugins = (
            from file in Directory.GetFiles(
                appPath + "\\bin\\Plugins", "*.dll",
                SearchOption.AllDirectories)
            let assembly = Assembly.LoadFile(file)
            select assembly)
            .ToArray();
                
        public override ICollection<Assembly> GetAssemblies()
        {
            var appPath =
                AppDomain.CurrentDomain.BaseDirectory;
            
            return base.GetAssemblies()
                .Union(this.plugins).ToArray();        
        }
    }
