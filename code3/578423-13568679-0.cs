            Type myGenericParam1 = myParam1.GetType();
            Type myGenericParam2 = myParam2.GetType();
            Type myGenericInterfaceType = typeof(IMyInterface<,>);
            Type myActualInterfaceType = myGenericInterfaceType.MakeGenericType(myGenericParam1, myGenericParam2);
            var proxyObjectContainer = typeof(MyProxyFactory).GetMethod("CreateProxy", new Type[] { }).MakeGenericMethod(new[] { myActualInterfaceType }).Invoke(null, new object[] { });
            var proxyObject = proxyObjectContainer.GetType().GetProperty("Proxy").GetValue(proxyObjectContainer, null);
