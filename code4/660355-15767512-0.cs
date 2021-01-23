    private object[] getConstructorArgs()
    {
        ConstructorInfo ctor = Constructor.GetGreediestConstructor(typeof (TTargetClass));
        var list = new List<object>();
        foreach (ParameterInfo parameterInfo in ctor.GetParameters())
        {
            Type dependencyType = parameterInfo.ParameterType;
            if (dependencyType.IsArray)
            {
                [...]
            }
            else if (dependencyType.Closes(typeof (IEnumerable<>)))
            {
                Type @interface = dependencyType.FindFirstInterfaceThatCloses(typeof (IEnumerable<>));
                Type elementType = @interface.GetGenericArguments().First();
                // Here's the interesting code:
                var builder = typeof (EnumerableBuilder<>).CloseAndBuildAs<IEnumerableBuilder>(_container,
                                                                                               elementType);
                list.Add(builder.ToEnumerable());
            }
            else
            {
                object dependency = _container.GetInstance(dependencyType);
                list.Add(dependency);
            }
        }
        return list.ToArray();
    }
