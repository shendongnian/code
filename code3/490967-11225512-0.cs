     static void Main(string[] args)
     {
         IUnityContainer container = new UnityContainer();
         container.RegisterType<ILogger, FileLogger>(new InjectionConstructor(new[] { "c:\\myLog.txt" }));
         ILogger logger = container.Resolve<FileLogger>();
         logger.Write("My message");
         Console.ReadLine();
     }
