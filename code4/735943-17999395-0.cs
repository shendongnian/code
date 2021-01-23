    class Program
        { 
            public ISodaService s { get; set; }
            static void Main(string[] args)
            {
                var resolver=SetUpContainer();
    			var instance=resolver.Resolve<Program>();
    			instance.Execute(args);
            }
    		
    		public void Execute(string[] args)
    		{
                Console.Write(s.GetSoda());
                Console.Read();
    		}
    
            private Autofac.IContainer void SetUpContainer()
            {
              var builder = new ContainerBuilder();
              builder.RegisterType<Soda>().As<ISoda>();
              builder.RegisterType<SodaService>().As<ISodaService>().PropertiesAutowired();
    		  builder.RegisterType<Program>().PropertiesAutowired();
              return builder.Build();
    
            }
        }
