        var assembly = Assembly.GetAssembly(typeof(Foo));
        Type customType = assembly.GetType("Foo");
        var actionMethodInfo = customType.GetMethod("AnyMethod");
        var foo = Activator.CreateInstance(customType);
        Action action = (Action)Delegate.CreateDelegate(typeof(Action), foo, actionMethodInfo);
