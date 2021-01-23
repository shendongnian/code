        YourContext _ctx;
        [TestInitialize]
        public  void Initiaslise()
        {
            YourNameDbInitialise initialiser = new YourNameDbInitialiseForTest();
            Database.SetInitializer(initialiser);
            _ctx = new YourNameContext();
            
            initialiser.InitializeDatabase(_ctx);         
        }
