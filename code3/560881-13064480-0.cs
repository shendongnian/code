    interface IEngineController
    {
        void Start(); //Uses algoritm in Config
        void Stop(); //Uses algoritm in Config
        IConfiguration Config { get; set; }
    }
    
    internal interface IConfiguration
    {
    }
    
    interface ISpecificConfiguration : IConfiguration
    {
    }
