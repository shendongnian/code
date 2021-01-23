    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Autofac;
    using Autofac.Configuration;
    
    namespace AutoFacTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                // Explicitly 
                var builder = new ContainerBuilder();
                builder.Register<UnitOfWork>(b => new UnitOfWork());
                builder.Register<Repository>(b => new Repository(b.Resolve<UnitOfWork>()));
    
                builder.Register(b => new Service(b.Resolve<Repository>(), b.Resolve<UnitOfWork>()));
    
                // Implicitly
                var typeBuilder = new ContainerBuilder();
                typeBuilder.RegisterType<UnitOfWork>();
                typeBuilder.RegisterType<Repository>();
                typeBuilder.RegisterType<Service>();
    
                // Config
                var configBuilder = new ContainerBuilder();
                configBuilder.RegisterModule(new ConfigurationSettingsReader("autofac"));
    
                var container = builder.Build();
                var typeContainer = typeBuilder.Build();
                var configContainer = configBuilder.Build();
    
    
                container.Resolve<Service>().DoAwesomeness();
                typeContainer.Resolve<Service>().DoAwesomeness();
                configContainer.Resolve<Service>().DoAwesomeness();
                Console.Read();
            }
        }
    
        public class Repository
        {
            private readonly UnitOfWork _unitOfWork;
            public Repository(UnitOfWork uow)
            {
                _unitOfWork = uow;
            }
    
            public void PrintStuff(string text)
            {
                Console.WriteLine(text);
            }
        }
       
        public class Service
        {
            private readonly Repository _repository;
            private readonly UnitOfWork _unitOfWork;
    
            public Service(Repository repo, UnitOfWork uow)
            {
                _repository = repo;
                _unitOfWork = uow;
            }
            public void DoAwesomeness()
            {
                _repository.PrintStuff("Did awesome stuff!");
                _unitOfWork.Commit();
            }
        }
    
        public class UnitOfWork
        {
            public bool Commit()
            {
                return true;
            }
        }
    
    
    }
