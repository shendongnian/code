    public class ConcreteFactory<T>  : AbstractFactory<T>
        {
            public override T CreateInstance(string typeName,params object[] parameters)
            {
                var path = Assembly.GetExecutingAssembly().CodeBase;
                var assembly = Assembly.LoadFrom(path);
                var type = assembly.GetTypes().SingleOrDefault(t => t.Name == typeName);
                return (T)Activator.CreateInstance(type, parameters);
            }
    }
