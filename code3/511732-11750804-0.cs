    public static void Do<T>(this IUnityContainer container, T args) where T : IMyInterface
    {
        foreach (var s in container.ResolveAll<IDoSomething<T>>())
            s.DoSomething(args);
    }
