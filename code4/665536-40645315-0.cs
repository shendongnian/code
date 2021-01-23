    //The email service factory is an async method
    public static async Task<EmailService> EmailServiceFactory() 
    {
      await Task.Delay(1000);
      return new EmailService();
    }
    
    class Service
    {
         //Constructor dependencies will be solved asynchronously:
         public Service(IEmailService email)
         {
         }
    } 
    
    var container = new Container();
    //Register an async factory:
    container.Register<IEmailService>(EmailServiceFactory);
    
    //Asynchronous GetInstance:
    var service = await container.GetInstanceAsync<Service>();
    
    //Safe synchronous, will fail if the solving path is not fully synchronous:
    var service = container.GetInstance<Service>();
