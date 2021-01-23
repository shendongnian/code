    protected override void ConfigureContainer()
        {
            base.ConfigureContainer();
    
            this.RegisterTypeIfMissing(typeof(IDatabase), typeof(DatabaseImpl ), true);
        }
