    int target = 1; // memory, nhibernate, entity framework
    switch (target)
    {
    	case 0:
    		ninjectKernel.Bind<IRepository<Person>>().ToMethod(x =>
    		{
    			var person = new MemoryRepository<Person>();
    			person.Save(new Person { Username = "Hello", Firstname = "Yo", FavoriteNumber = 9 }, null);
    			person.Save(new Person { Username= "See", Firstname = "Nice" }, null);
    
    			return person;
    		}
    		).InSingletonScope();
    		
    
    		break;
    
    	case 1:
    		ninjectKernel.Bind<ISession>().ToMethod(x => ModelsMapper.GetSessionFactory().OpenSession()).InRequestScope();
    		ninjectKernel.Bind<Ienablemuch.ToTheEfnhX.IRepository<Person>>().To<Ienablemuch.ToTheEfnhX.NHibernate.NhRepository<Person>>();
    		ninjectKernel.Bind<Ienablemuch.ToTheEfnhX.IRepository<Country>>().To<Ienablemuch.ToTheEfnhX.NHibernate.NhRepository<Country>>();
    
    
    		break;
    
    
    
    	case 2:
    
    		ninjectKernel.Bind<DbContext>().To<EfDbContext>().InRequestScope();
    		ninjectKernel.Bind<Ienablemuch.ToTheEfnhX.IRepository<Person>>().To<Ienablemuch.ToTheEfnhX.EntityFramework.EfRepository<Person>>();
    		ninjectKernel.Bind<Ienablemuch.ToTheEfnhX.IRepository<Country>>().To<Ienablemuch.ToTheEfnhX.EntityFramework.EfRepository<Country>>();
    
    		break;
    
    	default:
    		break;
    }
