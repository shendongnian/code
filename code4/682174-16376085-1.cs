    public class Loader : MarshalByRefObject
    {
        public IPostPlugin[] LoadPlugins(string assemblyName)
        {
            var ass = Assembly.Load(assemblyName);
            var types = from type in ass.GetTypes()
                    where typeof(IPostPlugin).IsAssignableFrom(type)
                    select type;
            var instances = types.Select(
                v => (IPostPlugin)Activator.CreateInstance(v)).ToArray();
            return instances;
        }
    }
