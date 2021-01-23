    static void Main()
    {
        ObjectFactory.Configure(x => x.AddRegistry<CoreRegistry>());
        var instance = ObjectFactory.GetInstance(typeof(IRenderer<string>));
        var methodInfo = instance.GetType().GetMethod("Render");
        methodInfo.Invoke(instance, new[] { new Generic<string>() });
    }
