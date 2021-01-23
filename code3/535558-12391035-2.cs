    public class Program
    {
        public static void Main(string[] args)
        {
            var registrar = new ContainerRegistrar();
            registrar.RegisterComponents(Lifetime.Transient, Environment.CurrentDirectory, "MyApp.Plugin.*.dll");
            var container = registrar.Build();
            
            // all extension points have been loaded. To load all menu extensions simply do something like:
            
            var menu = GetMainMenu();
            foreach (var registrar in container.ResolveAll<IMenuRegistrar>())
            {
                registrar.Register(menu);
            }
        }
    }
