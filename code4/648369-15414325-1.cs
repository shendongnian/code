    public class RepositoryToLoggerAdapter : ILogger
        {
            private IRepository adaptee;
    
            public InfrastructureLoggerToDatabaseAdapter(IRepository adaptee)
            {
                this.adaptee = adaptee;
            }
    
            public void Write(string data)
            {
                var log = new Log() { Value = data };
                adaptee.Create(log);   
            }
        }
    
    class Program
        {
            static void Main(string[] args)
            {
    
                ILogger logger = new InfrastructureDebugLogger();
                Console.Write("Data: ");
                
                string data = Console.ReadLine();
    
          //This step is redundant as the text will be shown on the screen as you type
    logger.Write(data);
                
    //Create an object of IRepository type.
    IRepository repository= new LogRepository();
    
    //The create method works as it should
    repository.Create(data);
    
    
    //You could not have stored the repository object in the logger variable if you did not have this adapter.
    
    			logger = new RepositoryToLoggerAdapter(repository);
    		
    //Effectively you now are calling the Create method of the Repository by calling the Write method of the logger.
    	
                logger.Write(data);
                Console.ReadKey();
            }
        }
