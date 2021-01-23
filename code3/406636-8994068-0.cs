	private static void RegisterServices(IKernel kernel)
	{
		kernel.Bind<ISessionFactory>()
			.ToMethod(c => new Configuration().Configure().BuildSessionFactory())
			.InSingletonScope();
		kernel.Bind<ISession>()
			.ToMethod((ctx) => ctx.Kernel.Get<ISessionFactory>().OpenSession())
			.InRequestScope();
		kernel.Bind<IRepository<>>().To<Repository<>>();		
	}   
