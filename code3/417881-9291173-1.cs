    var assembliesWithPluginBaseInThem = AppDomain.CurrentDomain.GetAssemblies()
        .Where(x =>
            x.GetTypes().Any(y =>
                typeof(Form).IsAssignableFrom(y) &&
                y.GetConstructors().Any(z =>
                    z.GetParameters().Count() == 1 && // or maybe you don't want exactly 1 param?
                    z.GetParameters().All(a => a.ParameterType.IsInterface)
                )
            )
        );
