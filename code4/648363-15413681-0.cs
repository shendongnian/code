    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Data: ");
            string data = Console.ReadLine();
            InfrastructureLoggerToDatabaseAdapter loggerToDatabaseAdapter = 
                new InfrastructureLoggerToDatabaseAdapter(new LogRepository());
            // Here, you're using a IRepository<Log>, but adapting it to be used as an ILogger...
            ILogger logger = loggerToDatabaseAdapter;
            logger.Write(data);
            Console.ReadKey();
        }
    }
