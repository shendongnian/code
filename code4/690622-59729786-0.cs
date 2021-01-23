       You can write this code in program.cs
         //if Debug
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[] 
                    { 
                    new MyService() 
                    };
            ServiceBase.Run(ServicesToRun);
            //if not in debug mode
            MyService service = new MyService();
            service.OnDebug();
            System.Threading.Thread.Sleep(System.Threading.Timeout.Infinite);
       in MyService class
       public void OnDebug()
        {
            OnStart(null);
        }
