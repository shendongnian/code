            String location = Factory.realAssemblyLocation ?? Assembly.GetExecutingAssembly().Location;
            ObjectHandle handle = Activator.CreateInstanceFrom(
                Factory.operatingDomain,
                location,
                typeof(MyType).FullName,
                false,
                BindingFlags.NonPublic | BindingFlags.Instance,
                null,
                new object[] { config },
                null,
                null);
