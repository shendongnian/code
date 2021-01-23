    public class Service
    {
        public void Start() 
        {
             // your code when started
        }
        public void Stop() 
        {
             // your code when stopped
        }
    }
    
    public class Program
    {
        public static void Main()
        {
            HostFactory.Run(x =>                                 
            {
                x.Service<Service>(s =>                    
                {
                   s.ConstructUsing(name=> new Service());   
                   s.WhenStarted(tc => tc.Start());            
                   s.WhenStopped(tc => tc.Stop());           
                });
                x.RunAsLocalSystem();                          
    
                x.SetDescription("My service description");      
                x.SetDisplayName("ServiceName");                    
                x.SetServiceName("ServiceName");                   
            });                                                 
        }
    }
