    static void Main()
    {
        ObjectFactory.Configure(x => x.AddRegistry<CoreRegistry>());
        var instance = ObjectFactory.GetInstance(typeof(IRenderer<string>));
        var methodInfos = instance.GetType().GetMethods().FirstOrDefault(x => x.Name == "Render");
        methodInfos.Invoke(instance, new[] { new Generic<string>() });
    }
