    public class GenerateSchema_Fixture
    {
        [Test]
        public void Can_generate_schema()
        {
            var cfg = new Configuration();
            cfg.Configure();
            cfg.AddAssembly(typeof (Product).Assembly);
            
            new SchemaExport(cfg).Execute(true /*script*/, true /*export to db*/,
                     false /*just drop*/, true /*format schema*/);
        }
    }
