    container.ConfigureAutoRegistration()
             .LoadAssemblyFrom(typeof(ITest).Assembly.Location)
             .LoadAssemblyFrom(typeof(Test).Assembly.Location)
             .Include(If.ImplementsITypeName, Then.Register())
             .ApplyAutoRegistration();
