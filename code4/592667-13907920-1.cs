    public void MakeTestData()
    {
        IGenerationSessionFactory factory = AutoPocoContainer.Configure(x =>
        {
            x.Conventions(c => { c.UseDefaultConventions(); });
            x.AddFromAssemblyContainingType<SimpleUser>();
        });
     
        IGenerationSession session = factory.CreateSession();
     
        IList<SimpleUser> users = session.List<SimpleUser>(1000).Get();
     
    }
