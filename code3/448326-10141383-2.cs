    public class ConfigurationFactory
    {
        const string Database = "";
        const string Server = "";
        public static Configuration Build()
        {           
            return Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2008.ConnectionString(
                    c => c.Database(Database).TrustedConnection().Server(Server)))
                .Mappings(m =>
                {
                    m.FluentMappings.AddFromAssemblyOf<ArticleMapping>();
                    m.HbmMappings.AddFromAssemblyOf<ArticleMapping>();
                })
                //.ExposeConfiguration(c => new SchemaExport(c).Execute(true, true, false))
                .BuildConfiguration();
        }
    }
