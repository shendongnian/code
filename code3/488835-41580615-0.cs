    using static ConsoleApplication.Developer;
    
    namespace ConsoleApplication
    {
        class Program
        {
            static void Main(string[] args)
            {
                // Global static function 
                DeveloperIsBorn(firstName: "Foo", lastname: "Bar")
                    .MakesAwesomeApp()
                    .Retires();
            }
        }
    }
    namespace ConsoleApplication
    {
        class Developer
        {
            public static Developer DeveloperIsBorn(string firstName, string lastname)
            {
                return new Developer();
            }
    
            public Developer MakesAwesomeApp()
            {
                return this;
            }
            public Developer InsertsRecordsIntoDatabaseForLiving()
            {
                return this;
            }
    
            public void Retires()
            {
               // Not really
            }        
        }
    }
