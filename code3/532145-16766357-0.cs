    container.Register(
        Castle.MicroKernel.Registration.Classes.FromAssemblyNamed(a)
        .WithServiceFirstInterface()
        .LifestylePerWebRequest()
    );
