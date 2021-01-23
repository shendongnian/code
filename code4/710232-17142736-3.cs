    class SQLFactory : FactoryBase
    {
        public override IDatabase GetDataLayer()
        {
            return new SQL();
        }
    }
