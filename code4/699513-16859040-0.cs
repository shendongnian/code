        private readonly IOrchardServices _services;
        public Migrations(IOrchardServices services) {
            _services = services;
        }
        public int Create() 
        {
            ContentDefinitionManager.AlterTypeDefinition("PlayerSearch", cfg => { });
            var content = _services.ContentManager.New("PlayerSearch");
            _services.ContentManager.Create(content);
            return 1;
        }
