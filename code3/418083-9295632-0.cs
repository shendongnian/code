    File file = new File(
        new List<IClass>
        {
            new Class(
                 new List<IInstanceMethod>
                 {
                     new InstanceMethod(
                         new List<IParameter>(),
                         new Body(
                             new Dependency1()
                             new Dependency2(),
                             new DependencyN()))
                 },
                 new List<IStaticMethod>(),
                 new List<IVariable>())
        },
        new List<IImport>());
